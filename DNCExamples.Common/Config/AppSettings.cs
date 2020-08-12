namespace DNCExamples.Common.Config
{
    /// <summary>
    /// Convinience class used to extract information relating to the application settings.
    /// </summary>
    /// <typeparam name="T">The Type of Settings required this is used to determine things like the Assembly etc.</typeparam>
    public class AppSettings<T> : IAppSettings
    {
        /// <summary>
        /// Abstraction Helper used to get at the running Enviroment Settings.
        /// </summary>
        public IEnvironmentHelper EnvironmentHelper { get; }

        /// <summary>
        /// Instantiates a class using the helper to get at some Env settings.
        /// </summary>
        /// <param name="environmentHelper"></param>
        public AppSettings(IEnvironmentHelper environmentHelper)
        {
            EnvironmentHelper = environmentHelper;
        }

        /// <summary>
        /// Returns the name of the Environment that the Application is running in.  This is determined by the ASPNETCORE_ENVIRONMENT and will default to "Development"
        /// </summary>
        public string EnvironmentName
        {
            get
            {
                return EnvironmentHelper.GetEnvironmentName();
            }

        }

        /// <summary>
        /// The Name of the Assembly that the Type Class is homed in.
        /// </summary>
        public string Name
        {
            get
            {
                return typeof(T).Assembly.GetName().Name;
            }
        }

        /// <summary>
        /// Pulls te Version from teh Assembly and will return it as a SemVewr "Major.Minor.Build" string
        /// </summary>
        public string Version
        {
            get
            {
                var version = typeof(T).Assembly.GetName().Version;
                return version.Major + "." + version.Minor + "." + version.Build;
            }
        }

    }
}
