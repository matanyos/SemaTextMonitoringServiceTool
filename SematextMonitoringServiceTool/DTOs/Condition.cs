using Newtonsoft.Json;

namespace SemaTextMonitoringServiceTool.DTOs
{
    public class Condition
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }

}
