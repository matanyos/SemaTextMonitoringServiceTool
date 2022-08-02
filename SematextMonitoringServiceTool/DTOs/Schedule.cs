using Newtonsoft.Json;

namespace SemaTextMonitoringServiceTool.DTOs
{
    public class Schedule
    {
        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("intervals")]
        public List<object> Intervals { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

}
