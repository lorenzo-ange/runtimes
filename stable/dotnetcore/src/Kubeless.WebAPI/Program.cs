using System;
using Kubeless.WebAPI.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PhotosiMessaging.Exceptions;
using Sentry.Extensibility;
using Sentry.Protocol;

namespace Kubeless.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var port = VariablesUtils.GetEnvVar("FUNC_PORT", "8080");
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddFilter("Microsoft", LogLevel.Warning);
                    logging.AddFilter("System", LogLevel.Warning);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var sentryEnabled = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SENTRY_DSN"));
                    if (sentryEnabled) {
                        webBuilder.UseSentry(options => {
                            options.Debug = true;
                            options.MinimumEventLevel = LogLevel.Warning;
                            options.MaxRequestBodySize = RequestSize.Always;
                        });
                    }
                    webBuilder.UseStartup<Startup>().UseUrls($"http://*:{port}");
                });
        }
    }
}
