using System;
using System.Threading.Tasks;
using Kubeless.Core.Interfaces;
using Kubeless.DisposableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kubeless.Functions;
using Kubeless.WebAPI.BackgroundServices;
using Prometheus;
using OpenTracing.Util;

namespace Kubeless.WebAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class RuntimeController : ControllerBase
    {
        private readonly ILogger<RuntimeController> _logger;
        private readonly IInvoker _invoker;
        private readonly IParameterHandler _parameterHandler;
        private readonly BackgroundWorkersService _backgroundWorkers;

        private static readonly Counter CallsCountTotal = Metrics
            .CreateCounter("kubeless_calls_total", "Number of calls processed.",
                new CounterConfiguration
                {
                    LabelNames = new[] {"status", "handler", "function", "runtime"}
                });

        private static readonly Histogram DurationSeconds = Metrics
            .CreateHistogram("kubeless_function_duration_seconds", "Duration of user function in seconds",
                new HistogramConfiguration
                {
                    LabelNames = new[] {"handler", "function", "runtime"}
                });

        public RuntimeController(ILogger<RuntimeController> logger, IInvoker invoker, IParameterHandler parameterHandler, BackgroundWorkersService backgroundWorkers)
        {
            _logger = logger;
            _invoker = invoker;
            _parameterHandler = parameterHandler;
            _backgroundWorkers = backgroundWorkers;
        }

        [AcceptVerbs("GET", "POST", "PUT", "PATCH", "DELETE")]
        public async Task<object> Execute()
        {
            _logger.LogInformation($"{DateTime.Now}: Function Started. HTTP Method: {Request.Method}, Path: {Request.Path}.");
            AddContextDataToTraceSpan();

            if (await _backgroundWorkers.EnqueueIfParallelConstraint(Request))
            {
                GlobalTracer.Instance.ActiveSpan?.SetTag("enqueued", "true");
                return true;
            }

            Event @event = null;
            Context context = null;
            try
            {
                (@event, context) = await _parameterHandler.GetFunctionParameters(Request);

                object output;
                var durationMetrics = DurationSeconds.WithLabels(context.ModuleName, context.FunctionName, context.Runtime);
                using (durationMetrics.NewTimer()) {
                    output = await _invoker.Execute(@event, context);
                }
                await @event.Extensions.DisposeAllAsync();

                _logger.LogInformation($"{DateTime.Now}: Function Executed. HTTP response: 200.");

                LogMetrics(context, 200);
                return output;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError(exception, $"{DateTime.Now}: Function Cancelled. HTTP Response: 408. Reason: Timeout.");
                LogMetrics(context, 408);
                return new StatusCodeResult(408);
            }
            catch (PhotosiMessaging.Exceptions.BaseException exception)
            {
                _logger.LogCritical(exception, $"{DateTime.Now}: PhotosiMessaging Exception. HTTP Response: 550. Reason: {exception.Message}.");
                LogMetrics(context, 550);
                Response.StatusCode = 550;
                return exception.PmsResponse;
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, $"{DateTime.Now}: Function Corrupted. HTTP Response: 500. Reason: {exception.Message}.");
                LogMetrics(context, 500);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("/healthz")]
        public IActionResult Health() => Ok();

        private void LogMetrics(Context context, int statusCode)
        {
            if (context != null)
            {
                CallsCountTotal
                    .WithLabels($"{statusCode}", context.ModuleName, context.FunctionName, context.Runtime)
                    .Inc();
            }
        }

        private void AddContextDataToTraceSpan()
        {
            var activeSpan = GlobalTracer.Instance.ActiveSpan;
            if (activeSpan == null)
            {
                return;
            }
            activeSpan.SetTag("func_handler", Environment.GetEnvironmentVariable("FUNC_HANDLER"));
            activeSpan.SetTag("func_runtime", Environment.GetEnvironmentVariable("FUNC_RUNTIME"));
            activeSpan.SetTag("service_name", Environment.GetEnvironmentVariable("SERVICE_NAME"));
            activeSpan.SetTag("hostname", Environment.GetEnvironmentVariable("HOSTNAME"));
        }
    }
}
