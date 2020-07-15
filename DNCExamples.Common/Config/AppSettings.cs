namespace DNCExamples.Common.Config
{

    public class AppSettings<T> : IAppSettings
    {
        public AppSettings(IEnvironmentHelper environmentHelper)
        {
            EnvironmentHelper = environmentHelper;
        }

        public string EnvironmentName
        {
            get
            {
                return EnvironmentHelper.GetEnvironmentName();
            }

        }

        public string Name
        {
            get
            {
                return typeof(T).Assembly.GetName().Name;
            }
        }

        public string Version
        {
            get
            {
                var version = typeof(T).Assembly.GetName().Version;
                return version.Major + "." + version.Minor + "." + version.Build;
            }
        }

        public IEnvironmentHelper EnvironmentHelper { get; }
    }
}
