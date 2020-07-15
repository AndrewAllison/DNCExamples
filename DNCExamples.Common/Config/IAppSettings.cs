namespace DNCExamples.Common.Config
{
    public interface IAppSettings
    {
        string EnvironmentName { get; }
        string Name { get; }
        string Version { get; }
    }
}