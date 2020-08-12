namespace DNCExamples.Common.Config
{
    /// <summary>
    /// Abstractino over the Curent Environment allowing Access to Env Vars etc.
    /// </summary>
    public interface IEnvironmentHelper
    {
        /// <summary>
        /// Gets a name of the current Environment
        /// </summary>
        /// <returns></returns>
        string GetEnvironmentName();
    }
}