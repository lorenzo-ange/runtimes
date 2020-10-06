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
            Func<string, string> getEnv = Environment.GetEnvironmentVariable;
            var gcCollectInterval = string.IsNullOrEmpty(getEnv("GC_COLLECT_INTERVAL")) ? int.Parse(getEnv("GC_COLLECT_INTERVAL")) : 5000;
            var gcLohCompact = string.IsNullOrEmpty(getEnv("GC_LOH_COMPACT")) ? bool.Parse(getEnv("LOH_COMPACT")) : true;

            while (!stoppingToken.IsCancellationRequested)
            {
                if (gcLohCompact)
                {
                    GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                }
                _logger.LogInformation("GC collection started");
                GC.Collect();
                _logger.LogInformation("GC collection ended");
                await Task.Delay(gcCollectInterval, stoppingToken);
            }
        }
    }
}