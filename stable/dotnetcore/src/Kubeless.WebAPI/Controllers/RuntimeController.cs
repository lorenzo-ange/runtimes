using System;
using System.Threading.Tasks;
using Kubeless.Core.Interfaces;
using Kubeless.DisposableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kubeless.Functions;
using Kubeless.WebAPI.Utils;
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

        private static readonly string[] MetricLabelNames =
            {"status", "handler", "function", "runtime", "event_namespace", "service_name"};

        private static string[] MetricLabels(Context context, Event @event, string statusCode = "UNKNOWN_STATUS_CODE")
        {
            var serviceName = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SERVICE_NAME")) ? "UNKNOWN_SERVICE" : Environment.GetEnvironmentVariable("SERVICE_NAME");
            var eventNamespace = string.IsNullOrEmpty(@event.EventNamespace) ? "UNKNOWN_EVENT_NAMESPACE" : @event.EventNamespace;
            return new[] {
                statusCode, context.ModuleName, context.FunctionName, context.Runtime, eventNamespace, serviceName
            };
        }

        private static readonly Counter CallsCountTotal = Metrics
            .CreateCounter("function_calls_total", "Number of calls processed.",
                new CounterConfiguration { LabelNames = MetricLabelNames });

        private static readonly Histogram DurationSeconds = Metrics
            .CreateHistogram("function_duration_seconds", "Duration of user function in seconds",
                new HistogramConfiguration { LabelNames = MetricLabelNames });
        public RuntimeController(ILogger<RuntimeController> logger, IInvoker invoker, IParameterHandler parameterHandler)
        {
            _logger = logger;
            _invoker = invoker;
            _parameterHandler = parameterHandler;
        }

        [AcceptVerbs("GET", "POST", "PUT", "PATCH", "DELETE")]
        public async Task<object> Execute()
        {
            _logger.LogInformation($"{DateTime.Now}: Function Started. HTTP Method: {Request.Method}, Path: {Request.Path}.");
            AddContextDataToTraceSpan();

            Event @event = null;
            Context context = null;
            try
            {
                (@event, context) = await _parameterHandler.GetFunctionParameters(Request);

                object output;
                var durationMetrics = DurationSeconds.WithLabels(MetricLabels(context, @event));
                using (durationMetrics.NewTimer())
                {
                    output = await _invoker.Execute(@event, context);
                }

                _logger.LogInformation($"{DateTime.Now}: Function Executed. HTTP response: 200.");

                LogMetrics(context, @event, 200);
                return output;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError(exception, $"{DateTime.Now}: Function Cancelled. HTTP Response: 408. Reason: Timeout.");
                LogMetrics(context, @event, 408);
                return new StatusCodeResult(408);
            }
            catch (PhotosiMessaging.Exceptions.BaseException exception)
            {
                _logger.LogPhotosiException(exception);
                LogMetrics(context, @event, 550);
                Response.StatusCode = 550;
                return exception.PmsResponse;
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, $"{DateTime.Now}: Function Corrupted. HTTP Response: 500. Reason: {exception.Message}.");
                LogMetrics(context, @event, 500);
                return new StatusCodeResult(500);
            }
            finally
            {
                if (@event != null)
                {
                    await @event.Extensions.DisposeAllAsync();
                }
            }
        }

        [HttpGet("/healthz")]
        public IActionResult Health() => Ok();

        private void LogMetrics(Context context, Event @event, int statusCode)
        {
            if (context != null)
            {
                CallsCountTotal
                    .WithLabels(MetricLabels(context, @event, $"{statusCode}"))
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
