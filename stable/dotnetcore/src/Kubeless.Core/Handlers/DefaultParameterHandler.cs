﻿using Kubeless.Core.Interfaces;
using Kubeless.Functions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kubeless.Core.Handlers
{
    public class DefaultParameterHandler : IParameterHandler
    {
        private readonly IConfiguration _configuration;

        public DefaultParameterHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<(Event, Context)> GetFunctionParameters(HttpRequest request)
        {
            var @event = await GetEvent(request);
            var context = GetContext();

            return (@event, context);
        }

        private async Task<Event> GetEvent(HttpRequest request)
        {
            var eventId = request.Headers["event-id"];
            var eventType = request.Headers["event-type"];
            var eventTime = request.Headers["event-time"];
            var eventNamespace = request.Headers["event-namespace"];
            var contentType = request.Headers["content-type"];

            if (request.Body.CanSeek) {
                request.Body.Position = 0;
            }

            using var sr = new StreamReader(request.Body);
            object data = await sr.ReadToEndAsync();

            if (contentType.Contains("application/json") && data.ToString().Length > 0) {
                data = JsonSerializer.Deserialize<dynamic>(data.ToString());
            }

            var extensions = new Extensions(request);
            return new Event(data, eventId, eventType, eventTime, eventNamespace, extensions);
        }

        private Context GetContext()
        {
            var moduleName = _configuration["MOD_NAME"];
            var functionName = _configuration["FUNC_HANDLER"];
            var functionPort = _configuration["FUNC_PORT"];
            var timeout = _configuration["FUNC_TIMEOUT"];
            var runtime = _configuration["FUNC_RUNTIME"];
            var memoryLimit = _configuration["FUNC_MEMORY_LIMIT"];

            return new Context(moduleName, functionName, functionPort, timeout, runtime, memoryLimit);
        }
    }
}
