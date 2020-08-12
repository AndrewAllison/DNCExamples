using DNCExamples.Common.Extensions;
using System;

namespace DNCExamples.Common.Config
{
    /// <summary>
    /// Helper Class to get Settings from the machines Enviromental Variables
    /// </summary>
    public class EnvironmentHelper : IEnvironmentHelper
    {
        /// <summary>
        /// Gets the name used in the Env Vars for ASPNETCORE_ENVIRONMENT
        /// </summary>
        /// <returns>The value of ASPNETCORE_ENVIRONMENT or Default value of Development.</returns>
        public string GetEnvironmentName()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ValueOrDefault("Development");
        }
    }
}
