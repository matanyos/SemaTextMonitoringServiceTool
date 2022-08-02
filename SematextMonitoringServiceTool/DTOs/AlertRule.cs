using Newtonsoft.Json;

namespace SemaTextMonitoringServiceTool.DTOs
{
    public class AlertRule
    {
        [JsonProperty("schedule")]
        public List<Schedule> Schedule { get; set; }

        [JsonProperty("minDelayBetweenNotificationsInMinutes")]
        public string MinDelayBetweenNotificationsInMinutes { get; set; }

        [JsonProperty("backToNormalNeeded")]
        public bool BackToNormalNeeded { get; set; }

        [JsonProperty("failedRunCountToAlert")]
        public int FailedRunCountToAlert { get; set; }

        [JsonProperty("notificationsEnabled")]
        public bool NotificationsEnabled { get; set; }

        [JsonProperty("useOnlyAlertRuleIntegrations")]
        public bool UseOnlyAlertRuleIntegrations { get; set; }
    }

}
