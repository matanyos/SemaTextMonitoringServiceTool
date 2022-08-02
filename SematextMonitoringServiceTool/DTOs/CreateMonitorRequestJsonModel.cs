using Newtonsoft.Json;

namespace SemaTextMonitoringServiceTool.DTOs
{
    public class CreateMonitorRequestJsonModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("interval")]
        public string Interval { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("locations")]
        public List<int> Locations { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("conditions")]
        public List<Condition> Conditions { get; set; }

        [JsonProperty("alertRule")]
        public AlertRule AlertRule { get; set; }

        [JsonProperty("monitorSSLExpiry")]
        public bool MonitorSSLExpiry { get; set; }

        [JsonProperty("monitorSSLChange")]
        public bool MonitorSSLChange { get; set; }

        [JsonProperty("allowInsecureSSL")]
        public bool AllowInsecureSSL { get; set; }
    }

}
