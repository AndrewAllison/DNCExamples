namespace DNCExamples.Common.Config
{
    /// <summary>
    /// Abstraction allowing access to settings for the Current Apps Environment
    /// </summary>
    public interface IAppSettings
    {
        /// <summary>
        /// Name of the Environment the application is running under e.g Development, Stagin, Production
        /// </summary>
        string EnvironmentName { get; }
        /// <summary>
        /// Name of the Applicatino itsself 
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Version number of the Application
        /// </summary>
        string Version { get; }
    }
}