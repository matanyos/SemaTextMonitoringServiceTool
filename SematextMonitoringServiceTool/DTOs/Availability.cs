using Newtonsoft.Json;

namespace SemaTextMonitoringServiceTool.DTOs
{
    public class Availability
    {
        [JsonProperty("day")]
        public decimal Day { get; set; }

        [JsonProperty("week")]
        public decimal Week { get; set; }

        [JsonProperty("month")]
        public decimal Month { get; set; }

        [JsonProperty("custom")]
        public decimal Custom { get; set; }
    }


}
