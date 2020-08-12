using System;
using DNCExamples.Common.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DNCExamples.Api.Controllers
{
    /// <summary>
    /// Services Controller
    /// </summary>
    /// <remarks>
    /// Deals wit the services that are trunning in the background
    /// </remarks>
    [Route("app")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly ILogger<AppController> _logger;
        private IAppSettings Settings { get; }

        /// <summary>
        /// Constructor, Takes paramaters and INstantiates the controller.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="settings"></param>
        public AppController(ILogger<AppController> logger, IAppSettings settings)
        {
            _logger = logger;
            Settings = settings;
        }

        /// <summary>
        /// Returns a Health check indicating if the server is up.
        /// </summary>
        /// <response code="200"></response>
        [HttpGet]
        [Route("")]
        public ActionResult GetHealthCheck()
        {
            HealthCheckResults healthCheckResults = new HealthCheckResults()
            {
                Status = "OK",
                ServiceName = Settings.Name,
                Environment = Settings.EnvironmentName,
                ExecutedOn = DateTime.UtcNow,
                Version = Settings.Version
            };

            _logger.LogInformation("Getting Health Check {@healthCheck}", healthCheckResults);

            return Ok(healthCheckResults);
        }
    }
}
