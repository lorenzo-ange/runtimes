using System;
using Microsoft.Extensions.Logging;
using PhotosiMessaging.Exceptions;

namespace Kubeless.WebAPI.Utils
{
    public static class LoggerExtensions
    {
        public static void LogPhotosiException(this ILogger logger, BaseException exception)
        {
            var logLevel = exception.Level switch
            {
                Level.Debug => LogLevel.Debug,
                Level.Info => LogLevel.Information,
                Level.Warning => LogLevel.Warning,
                Level.Error => LogLevel.Error,
                Level.Fatal => LogLevel.Critical,
                _ => LogLevel.Critical
            };
            logger.Log(logLevel, exception, $"{DateTime.Now}: PhotosiMessaging Exception. HTTP Response: 550. Reason: {exception.Message}.");
        }
    }
}