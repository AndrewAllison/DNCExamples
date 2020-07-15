using DNCExamples.Common.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNCExamples.Common.Logging
{
    public static class SeriLogHelper
    {
        public static Logger CreateLoggerConfig(IConfiguration configuration, IAppSettings appSettings)
        {

            var logger = new LoggerConfiguration()
                                   .ReadFrom.Configuration(configuration)
                                   .Enrich.WithProperty("Application",appSettings.Name)
                                   .Enrich.WithProperty("Environment", appSettings.EnvironmentName)
                                   .Enrich.WithProperty("Version", appSettings.Version)
                                   .CreateLogger();

            Log.Logger = logger;

            return logger;
        }

        public static ILogger<T> GetLogger<T>(Logger loggs)
        {
            var loggerFactory = (ILoggerFactory)new LoggerFactory();
            loggerFactory.AddSerilog(loggs);

            return loggerFactory.CreateLogger<T>();
        }
    }
}
