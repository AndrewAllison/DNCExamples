using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNCExamples.Api.StartUp;
using DNCExamples.Common.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DNCExamples.Api
{
    /// <summary>
    /// Class representing the startup needs of the WebApi
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Provides applicatino settings for the startUp
        /// </summary>
        public AppSettings<Startup> Settings { get; set; }
        /// <summary>
        /// Configuration element holding information relating the the settings provided.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Constructs the startupinstance
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            IEnvironmentHelper environmentHelper = new EnvironmentHelper();
            Settings = new AppSettings<Startup>(environmentHelper);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            SwaggerConfig.ServicesConfiguration(services, Settings);

            services.AddControllers();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            WebConfig.AppConfiguration(app, env);
            SwaggerConfig.AppConfiguration(app, Settings);
        }
    }
}
