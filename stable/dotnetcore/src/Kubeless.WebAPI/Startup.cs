using Datadog.Trace.OpenTracing;
using Kubeless.Core.Handlers;
using Kubeless.Core.Interfaces;
using Kubeless.Core.Invokers;
using Kubeless.WebAPI.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTracing.Util;
using Prometheus;
using OpenTracing.Contrib.NetCore.Configuration;
using System.Collections.Generic;
using System;

namespace Kubeless.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var function = FunctionFactory.GetFunction(Configuration);
            var timeout = FunctionFactory.GetFunctionTimeout(Configuration);

            var tracingEnabled = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DD_AGENT_HOST"));
            if (tracingEnabled) {
                ConfigureTracing(services);
            }

            services.AddTransient<IInvoker>(_ => new CompiledFunctionInvoker(function, timeout));
            services.AddSingleton<IParameterHandler>(new DefaultParameterHandler(Configuration));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllers());

            app.UseCors(builder =>
                builder
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod());
            
            app.UseMetricServer();
        }

        private void ConfigureTracing(IServiceCollection services)
        {
            OpenTracing.ITracer tracer = OpenTracingTracerFactory.CreateTracer();
            GlobalTracer.Register(tracer);

            services.AddOpenTracingCoreServices(otBuilder =>
            {
                otBuilder.AddAspNetCore()
                    .AddCoreFx()
                    .AddLoggerProvider();
            });

            services.Configure<AspNetCoreDiagnosticOptions>(options =>
            {
                options.Hosting.IgnorePatterns.Add(x =>
                {
                    var ignoredPaths = new List<string> {"/healthz", "/metrics"};
                    return ignoredPaths.Contains(x.Request.Path);
                });
            });
        }
    }
}
