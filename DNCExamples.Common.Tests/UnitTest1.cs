using DNCExamples.Common.Config;
using DNCExamples.Common.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Xunit;

namespace DNCExamples.Common.Tests
{

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var configuration = new ConfigHelper().Configuration;
            var appSettings = TestHelpers.GetAppSettings();

            using var logConfig = SeriLogHelper.CreateLoggerConfig(configuration, appSettings);
            var requestTraceId = $"Test-{DateTime.Now.ToString("yyyyMMddhhmmss")}";

            var logger = SeriLogHelper.GetLogger<UnitTest1>(logConfig);
            var options = new Dictionary<string, object> { { "requestTraceId", requestTraceId } };
            using (logger.BeginScope(options))
            {
                logger.LogInformation("Should_Upload_Products starting");
                logger.LogDebug("Should_Upload_Products starting");
                logger.LogWarning("Should_Upload_Products starting");
                logger.LogError("Should_Upload_Products starting");
                logger.LogInformation("Should_Upload_Products complete");
            }
            
        }
    }
}
