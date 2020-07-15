using DNCExamples.Common.Config;
using Moq;

namespace DNCExamples.Common.Tests
{
    public static class TestHelpers
    {
        public static IAppSettings GetAppSettings()
        {
            Mock<IAppSettings> mockAppSettings = new Mock<IAppSettings>();
            mockAppSettings.Setup(c => c.EnvironmentName).Returns("Testing");
            mockAppSettings.Setup(c => c.Name).Returns("TestApp");
            mockAppSettings.Setup(c => c.Version).Returns("V1.0.0");

            return mockAppSettings.Object;
        }
    }
}
