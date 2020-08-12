using Microsoft.Extensions.Configuration;

namespace DNCExamples.Common.Config
{
    /// <summary>
    /// Abstraction allowing access to Configuration Instances
    /// </summary>
    public interface IConfigHelper
    {
        /// <summary>
        /// Instance of A conficuration object allowing applicatino wide config / settings to be recalled.
        /// </summary>
        public IConfiguration Configuration { get; set; }
    }
}
