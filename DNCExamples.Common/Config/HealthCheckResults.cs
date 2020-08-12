using System;

namespace DNCExamples.Common.Config
{
    /// <summary>
    /// Represents a response object containing information about the overall health of the service.
    /// </summary>
    public class HealthCheckResults
    {
        /// <summary>
        /// Current Environment. E.g. Productino, Development
        /// </summary>
        public string Environment { get; set; }
        /// <summary>
        /// DateTime of when the action was executed.
        /// </summary>
        public DateTime ExecutedOn { get; set; }
        /// <summary>
        /// Name of the service that the check is being run against
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// Status of the Services usually OK
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The version of the service often populated from teh Assembly info for that Assembly.
        /// </summary>
        public string Version { get; set; }
    }
}
