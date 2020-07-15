using Microsoft.Extensions.Configuration;

namespace DNCExamples.Common.Config
{
    public interface IConfigHelper
    {
        public IConfiguration Configuration { get; set; }
    }
}
