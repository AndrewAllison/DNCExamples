using Microsoft.Extensions.Configuration;

namespace DNCExamples.Common.Config
{
    /// <summary>
    /// Convinience wrapper around the Configuration Builder
    /// </summary>
    public class ConfigHelper : IConfigHelper
    {

        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Builds a configuraiton component based on the passed environment
        /// </summary>
        public ConfigHelper(string environment = "Development")
        {
            Configuration = new ConfigurationBuilder()
                                         .AddJsonFile("appsettings.json", optional: false)
                                         .AddJsonFile($"appsettings.{environment}.json", optional: false)
                                         .AddEnvironmentVariables()
                                         .Build();
        }
    }
}
