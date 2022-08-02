using Newtonsoft.Json;

namespace SemaTextMonitoringServiceTool.DTOs
{
    internal class AllMonitorsJsonModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }
    }
}
