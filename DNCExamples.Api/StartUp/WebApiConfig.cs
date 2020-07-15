using DNCExamples.Api.MiddleWare;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DNCExamples.Api.StartUp
{
    /// <summary>
    /// Provides some basic Configuratino Elements for standard WebApi's
    /// </summary>
    public static class WebConfig
    {
        /// <summary>
        /// Configures standard http and Web API elements.
        /// </summary>
        /// <param name="services"></param>
        public static void ServicesConfiguration(IServiceCollection services)
        {
            // SECURITY - Set up a Policy for CORS etc.       
            services.AddCors(o => o.AddPolicy("SimplePolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddOptions();
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddHttpClient();
        }

        /// <summary>
        /// Some Standard applicaiton configuration.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public static void AppConfiguration(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("SimplePolicy");

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseMiddleware<WebRequestLogger>();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
