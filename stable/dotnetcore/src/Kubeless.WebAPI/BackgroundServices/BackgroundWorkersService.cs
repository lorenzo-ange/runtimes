using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeetleX.Redis;
using Kubeless.Core.Interfaces;
using Kubeless.WebAPI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SlsParallelismConstraint;

namespace Kubeless.WebAPI.BackgroundServices
{
    public class BackgroundWorkersService : BackgroundService
    {
        private static readonly HttpClient HttpClient = new HttpClient(
            new SocketsHttpHandler {
                PooledConnectionLifetime = new TimeSpan(0, 0, 2),
            }
        );

        private static int _functionParallelismConstraint = 0;
        private static string _functionUrl;
        private static string _jobQueueName;
        private readonly ILogger<BackgroundWorkersService> _logger;

        private readonly Dictionary<string, int> _workersRestarts = new Dictionary<string, int>();
        private const int MaxWorkerRestarts = 10;

        private const string WorkerCallHeader = "x-worker-call";

        public BackgroundWorkersService(ILogger<BackgroundWorkersService> logger, IInvoker invoker)
        {
            _logger = logger;

            var functionAttrs = invoker.MethodInfo.GetCustomAttributes(false);
            var parallelismConstraint = (ParallelismConstraint) functionAttrs.FirstOrDefault(a => a is ParallelismConstraint);
            _functionParallelismConstraint = parallelismConstraint?.Parallelism ?? 0;

            var functionPort = VariablesUtils.GetEnvVar("FUNC_PORT", "8080");
            _functionUrl = $"http://localhost:{functionPort}";

            _jobQueueName = $"JobQueue-{invoker.Function.ModuleName}-{invoker.Function.FunctionHandler}";
        }

        private static RedisDB GetRedisDb()
        {
            var redisHost = Environment.GetEnvironmentVariable("BACKGROUND_WORKERS_REDIS_HOST");
            if (string.IsNullOrEmpty(redisHost))
            {
                throw new Exception("Trying to use BackgroundWorkers without BACKGROUND_WORKERS_REDIS_HOST env var");
            }
            var db = new RedisDB();
            db.Host.AddReadHost(redisHost);
            db.Host.AddWriteHost(redisHost);
            return db;
        }

        private async Task<bool> LaunchFunction(string data, CancellationToken stoppingToken)
        {
            var content = new StringContent(data, Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json") {CharSet = "utf-8"};

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, _functionUrl) {Content = content};
            httpRequest.Headers.Add(WorkerCallHeader, "true");

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
                var jobQueue = db.CreateList<string>(_jobQueueName);

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

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                if (_functionParallelismConstraint == 0)
                {
                    _logger.LogInformation("BackgroundWorkersService no workers to start, shutting down");
                    return;
                }

                _logger.LogInformation("BackgroundWorkersService starting workers");
                var workers = new List<Task>();
                for (var i = 0; i < _functionParallelismConstraint; i++)
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

        public static async Task<bool> EnqueueIfParallelConstraint(HttpRequest request)
        {
            if (_functionParallelismConstraint <= 0)
            {
                // this function has no constraints on its parallelism
                return false;
            }

            if (request.Headers[WorkerCallHeader].Any())
            {
                // this is a call from a background worker
                return false;
            }

            // push data to redis
            using var sr = new StreamReader(request.Body, leaveOpen: true);
            var data = await sr.ReadToEndAsync();
            using var db = GetRedisDb();
            var jobQueue = db.CreateList<string>(_jobQueueName);
            await jobQueue.Push(data);

            return true;
        }
    }
}