using System;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Kubeless.WebAPI.BackgroundServices
{
    public class GcBackgroundService : BackgroundService
    {
        private readonly ILogger<GcBackgroundService> _logger;
        public GcBackgroundService(ILogger<GcBackgroundService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Func<string, string> config = Environment.GetEnvironmentVariable;
            var gcCollectInterval = string.IsNullOrEmpty(config("GC_COLLECT_INTERVAL")) ? 5000 : int.Parse(config("GC_COLLECT_INTERVAL"));
            var gcLohCompact = string.IsNullOrEmpty(config("GC_LOH_COMPACT")) ? true : bool.Parse(config("LOH_COMPACT"));

            while (!stoppingToken.IsCancellationRequested)
            {
                if (gcLohCompact)
                {
                    GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                }
                _logger.LogInformation($"{DateTime.Now}: GC collection started");
                GC.Collect();
                _logger.LogInformation($"{DateTime.Now}: GC collection ended");
                await Task.Delay(gcCollectInterval, stoppingToken);
            }
        }
    }
}