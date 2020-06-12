using Kubeless.WebAPI.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Sentry.Extensibility;

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
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseSentry(options => {
                        options.Debug = true;
                        options.MaxRequestBodySize = RequestSize.Always;
                    });
                    webBuilder.UseStartup<Startup>().UseUrls($"http://*:{port}");
                });
        }
    }
}
