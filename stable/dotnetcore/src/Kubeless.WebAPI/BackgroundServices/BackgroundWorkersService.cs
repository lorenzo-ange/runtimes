using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeetleX.Redis;
using Kubeless.WebAPI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SlsParallelismConstraint;

namespace Kubeless.WebAPI.BackgroundServices
{
    public class BackgroundWorkersService : BackgroundService
    {
        private static readonly string FunctionPort = VariablesUtils.GetEnvVar("FUNC_PORT", "8080");
        private static readonly string FunctionUrl = $"http://localhost:{FunctionPort}";

        private static readonly string RedisHost = Environment.GetEnvironmentVariable("BACKGROUND_WORKERS_REDIS_HOST");
        private static readonly string ModuleName = Environment.GetEnvironmentVariable("MOD_NAME");
        private static readonly string FunctionHandler = Environment.GetEnvironmentVariable("FUNC_HANDLER");
        private static readonly string JobQueueName = $"JobQueue-{ModuleName}-{FunctionHandler}";
        private const string BypassQueueHeader = "x-bypass-queue";

        private static readonly HttpClient HttpClient = new HttpClient(
            new SocketsHttpHandler {
                PooledConnectionLifetime = new TimeSpan(0, 0, 2),
            }
        );
        
        private static int _workersNumber = -1;

        private readonly ILogger<BackgroundWorkersService> _logger;
        private readonly Dictionary<string, int> _workersRestarts = new Dictionary<string, int>();
        private const int MaxWorkerRestarts = 10;

        public BackgroundWorkersService(ILogger<BackgroundWorkersService> logger)
        {
            _logger = logger;
        }

        private static RedisDB GetRedisDb()
        {
            if (string.IsNullOrEmpty(RedisHost))
            {
                throw new Exception("Trying to use BackgroundWorkers without BACKGROUND_WORKERS_REDIS_HOST env var");
            }
            var db = new RedisDB();
            db.Host.AddReadHost(RedisHost);
            db.Host.AddWriteHost(RedisHost);
            return db;
        }

        private async Task<bool> LaunchFunction(string data, CancellationToken stoppingToken)
        {
            var content = new StringContent(data, Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json") {CharSet = "utf-8"};

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, FunctionUrl) {Content = content};
            httpRequest.Headers.Add(BypassQueueHeader, "true");

            var response = await HttpClient.SendAsync(httpRequest, stoppingToken);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogCritical($"BackgroundWorker function failed with statusCode {response.StatusCode}");
                return false;
            }
            return true;
        }

        private async Task ExecuteWorker(string id, CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation($"W.{id} started");
                using var db = GetRedisDb();
                var jobQueue = db.CreateList<string>(JobQueueName);

                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation($"W.{id} listening for jobs");
                    // blocking read from redis
                    var data = await jobQueue.BRPop();

                    _logger.LogInformation($"W.{id} {data}");
                    var success = await LaunchFunction(data, stoppingToken);
                    _logger.LogInformation($"W.{id} {success}");
                }

                _logger.LogInformation($"W.{id} stopped");
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.ToString());
                if (_workersRestarts[id] >= MaxWorkerRestarts)
                {
                    _logger.LogCritical($"W.{id} max restarts reached");
                    return;
                }

                _logger.LogInformation($"W.{id} restarting worker");
                _workersRestarts[id]++;
                await ExecuteWorker(id, stoppingToken);
            }
        }

        private async Task WaitForWorkersNumber(CancellationToken stoppingToken, int pollingIntervalMs = 1000)
        {
            // wait until workers number will be set by a call to the QueueIfParallelConstraint method

            while (!stoppingToken.IsCancellationRequested)
            {
                if (_workersNumber != -1)
                {
                    return;
                }
                await Task.Delay(pollingIntervalMs, stoppingToken);
            }

            throw new Exception("Cancellation requested");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation("BackgroundWorkersService started, waiting for workers number");
                await WaitForWorkersNumber(stoppingToken);

                _logger.LogInformation("BackgroundWorkersService starting workers");
                var workers = new List<Task>();
                for (var i = 0; i < _workersNumber; i++)
                {
                    var workerId = $"{i}";
                    _workersRestarts[workerId] = 0;
                    workers.Add(ExecuteWorker(workerId, stoppingToken));
                }

                await Task.WhenAll(workers);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e.ToString());
            }
        }

        public static async Task<bool> EnqueueIfParallelConstraint(HttpRequest request, MethodInfo methodInfo)
        {
            if (request.Headers[BypassQueueHeader].Any())
            {
                // this is a call from a background worker
                return false;
            }

            var attrs = methodInfo.GetCustomAttributes(false);
            var parallelismConstraint = (ParallelismConstraint) attrs.FirstOrDefault(a => a is ParallelismConstraint);
            if (parallelismConstraint == null)
            {
                // this function does not have ParallelismConstraint annotation
                return false;
            }

            // set workersNumber if not already set
            if (_workersNumber == -1)
            {
                _workersNumber = parallelismConstraint.Parallelism;
            }

            // push data to redis
            var data = await new StreamReader(request.Body, leaveOpen: true).ReadToEndAsync();
            using var db = GetRedisDb();
            var jobQueue = db.CreateList<string>(JobQueueName);
            await jobQueue.Push(data);

            return true;
        }
    }
}