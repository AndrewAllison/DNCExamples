using System; 
using DNCExamples.Common.Config;
using DNCExamples.Common.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DNCExamples.Api
{
    /// <summary>
    /// Main Entry point for the application
    /// </summary>
    public static class Program
    {
        private static ILogger<Startup> logger;
        /// <summary>
        /// Will create a host builder whilst adding some of the desired dependencies
        /// </summary>
        /// <remarks>
        /// This will be where you can assign things like th eLogger and the application config.
        /// </remarks>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            IEnvironmentHelper environmentHelper = new EnvironmentHelper();
            AppSettings<Startup> appSettings = new AppSettings<Startup>(environmentHelper);
            var configuration = new ConfigHelper(appSettings.EnvironmentName).Configuration;

            var logConfig = SeriLogHelper.CreateLoggerConfig(configuration, appSettings);
            logger = SeriLogHelper.GetLogger<Startup>(logConfig);

            webBuilder.UseStartup<Startup>();
        });


        /// <summary>
        /// Main starting point for the application to spin up.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {            
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.LogError("DNC:Program:Error {@exception}", ex);
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
