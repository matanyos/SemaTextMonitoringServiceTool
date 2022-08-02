using Newtonsoft.Json;

namespace SemaTextMonitoringServiceTool.DTOs
{
    public class Datum
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("interval")]
        public string Interval { get; set; }

        [JsonProperty("intervalInSeconds")]
        public int IntervalInSeconds { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("locations")]
        public Locations Locations { get; set; }

        [JsonProperty("lastScheduledAt")]
        public object LastScheduledAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("appId")]
        public int AppId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("conditions")]
        public List<Condition> Conditions { get; set; }

        [JsonProperty("availability")]
        public Availability Availability { get; set; }

        [JsonProperty("lastFailedResult")]
        public LastFailedResult LastFailedResult { get; set; }
    }


}
