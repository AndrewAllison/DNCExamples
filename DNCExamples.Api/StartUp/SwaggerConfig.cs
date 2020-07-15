using DNCExamples.Common.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace DNCExamples.Api.StartUp
{
    /// <summary>
    /// Helps Configure a swagger environment
    /// </summary>
    public static class SwaggerConfig
    {
        /// <summary>
        /// Insttructs teh Applicatino to Use Swagger.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="settings"></param>
        public static void AppConfiguration(IApplicationBuilder app, AppSettings<Startup> settings)
        {
            // SWAGGER
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            string swaggerDocsLocation = $"/swagger/{settings.Name}/swagger.json";
            app.UseSwaggerUI(c => c.SwaggerEndpoint(swaggerDocsLocation, $"{settings.Name}"));
        }

        /// <summary>
        /// Adds the required elements to the DI container to allow Swagger to be Configured.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settings"></param>
        public static void ServicesConfiguration(IServiceCollection services, AppSettings<Startup> settings)
        {
            // SWAGGER - Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc($"{settings.Name}", new OpenApiInfo
                {
                    Title = $"{settings.Name}",
                    Description = "API Documentation",
                    Version = settings.Version
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{settings.Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
