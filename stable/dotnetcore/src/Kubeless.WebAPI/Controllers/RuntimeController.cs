using System;
using System.Threading.Tasks;
using Kubeless.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kubeless.Functions;
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

        public RuntimeController(ILogger<RuntimeController> logger, IInvoker invoker, IParameterHandler parameterHandler)
        {
            _logger = logger;
            _invoker = invoker;
            _parameterHandler = parameterHandler;
        }

        [AcceptVerbs("GET", "POST", "PUT", "PATCH", "DELETE")]
        public async Task<object> Execute()
        {
            _logger.LogInformation("{0}: Function Started. HTTP Method: {1}, Path: {2}.", DateTime.Now.ToString(), Request.Method, Request.Path);
            AddContextDataToTraceSpan();

            Event @event = null;
            Context context = null;
            try
            {
                (@event, context) = await _parameterHandler.GetFunctionParameters(Request);

                object output;
                using (DurationSeconds.WithLabels(context.ModuleName, context.FunctionName, context.Runtime).NewTimer()) {
                    output = await _invoker.Execute(@event, context);
                }

                _logger.LogInformation("{0}: Function Executed. HTTP response: {1}.", DateTime.Now.ToString(), 200);

                LogMetrics(context, 200);
                return output;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError(exception, "{0}: Function Cancelled. HTTP Response: {1}. Reason: {2}.", DateTime.Now.ToString(), 408, "Timeout");
                LogMetrics(context, 408);
                return new StatusCodeResult(408);
            }
            catch (PhotosiMessaging.Exceptions.BaseException exception)
            {
                _logger.LogCritical(exception, "{0}: PhotosiMessaging Exception. HTTP Response: {1}. Reason: {2}.", DateTime.Now.ToString(), 550, exception.Message);
                LogMetrics(context, 550);
                Response.StatusCode = 550;
                return exception.PmsResponse;
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, "{0}: Function Corrupted. HTTP Response: {1}. Reason: {2}.", DateTime.Now.ToString(), 500, exception.Message);
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
            activeSpan.SetTag("func_handler", Environment.GetEnvironmentVariable("FUNC_HANDLER"));
            activeSpan.SetTag("func_runtime", Environment.GetEnvironmentVariable("FUNC_RUNTIME"));
            activeSpan.SetTag("service_name", Environment.GetEnvironmentVariable("SERVICE_NAME"));
            activeSpan.SetTag("hostname", Environment.GetEnvironmentVariable("HOSTNAME"));
        }
    }
}
