using DNCExamples.Common.Extensions;
using System;

namespace DNCExamples.Common.Config
{
    public class EnvironmentHelper : IEnvironmentHelper
    {
        public string GetEnvironmentName()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ValueOrDefault("Development");
        }
    }
}
