using DNCExamples.Common.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;

namespace DNCExamples.Common.Logging
{
    /// <summary>
    /// Convinience wrapper around the SeriLog library, makes gettting loggers a lot simpler. 
    /// </summary>
    public static class SeriLogHelper
    {
        /// <summary>
        /// Will create an initial logger using the provided configuration, Also will Enrich with some basic appsettings details
        /// </summary>
        /// <param name="configuration">The provided configuration that should contain Serilog details from the appsettings.json files.</param>
        /// <param name="appSettings">Using the Common AppSettigns object to get at some basic props.</param>
        /// <returns>And Instance of a logger all peppered with Serilog Goodness.</returns>
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

        /// <summary>
        /// Generic Ilogger getter.
        /// </summary>
        /// <typeparam name="T">The type which the logger will identify</typeparam>
        /// <param name="logger">Initial logger that will be used as a factory to generate an ILogger<T></param>
        /// <returns>A typed instance of ILogger<T></returns>
        public static ILogger<T> GetLogger<T>(Logger logger)
        {
            var loggerFactory = (ILoggerFactory)new LoggerFactory();
            loggerFactory.AddSerilog(logger);

            return loggerFactory.CreateLogger<T>();
        }
    }
}
