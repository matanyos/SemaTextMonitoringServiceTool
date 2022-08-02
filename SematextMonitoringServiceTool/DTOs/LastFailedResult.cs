using Newtonsoft.Json;

namespace SemaTextMonitoringServiceTool.DTOs
{
    public class LastFailedResult
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("runId")]
        public int RunId { get; set; }
    }


}
