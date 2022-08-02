using Newtonsoft.Json;
using SemaTextMonitoringServiceTool.DTOs;
using SemaTextMonitoringServiceTool.Interfaces;

namespace SemaTextMonitoringServiceTool
{
    public class SemaTextHttpMonitorService : ISemaTextHttpMonitorService
    {
        private readonly RequestSender requestSender;

        public SemaTextHttpMonitorService(RequestSender requestSender)
        {
            this.requestSender = requestSender;
        }

        public async Task<string> GetEndPointHttpMonitorStatus(string endpointName,string appId)
        {
            var url = $"https://apps.eu.sematext.com/synthetics-api/api/apps/{appId}/monitors";
            var result = await requestSender.SendRequest(url, HttpMethod.Get, string.Empty);

            var endPointDataObject = JsonConvert.DeserializeObject<AllMonitorsJsonModel>(result.Value);
            if (endPointDataObject != null)
            {
                var endPointData = endPointDataObject.Data.Single(x => x.Name.Equals(endpointName, StringComparison.OrdinalIgnoreCase));
            
                return JsonConvert.SerializeObject(endPointData,Formatting.Indented);
            }

            return "Could not find the specified EndPoint name";
        }

        public async Task<string> CreateNewEndPointHttpMonitor(string name, string endpoint, string appId, HttpMethod method, Interval intervalInMinutes)
        {
            var request = new CreateMonitorRequestJsonModel
            {
                Url = endpoint,
                AlertRule = new AlertRule
                {
                    BackToNormalNeeded = true,
                    FailedRunCountToAlert = 1,
                    NotificationsEnabled = true,
                    UseOnlyAlertRuleIntegrations = false,
                    MinDelayBetweenNotificationsInMinutes = "10",
                    Schedule = new List<Schedule>
                     {
                         new (){Day = "Sunday",Index = 1,Intervals = new List<object>(),Label = "SUN",Type = "ACTIVE"},
                         new (){Day = "Monday",Index = 2,Intervals = new List<object>(),Label = "MON",Type = "ACTIVE"},
                         new (){Day = "Tuesday",Index = 3,Intervals = new List<object>(),Label = "TUE",Type = "ACTIVE"},
                         new (){Day = "Wednesday",Index = 4,Intervals = new List<object>(),Label = "WED",Type = "ACTIVE"},
                         new (){Day = "Thursday",Index = 5,Intervals = new List<object>(),Label = "THU",Type = "ACTIVE"},
                         new (){Day = "Friday",Index = 6,Intervals = new List<object>(),Label = "FRI",Type = "ACTIVE"},
                         new (){Day = "Saturday",Index = 6,Intervals = new List<object>(),Label = "SAT",Type = "ACTIVE"}
                     }
                },
                AllowInsecureSSL = false,
                MonitorSSLChange = true,
                MonitorSSLExpiry = true,
                Conditions = new List<Condition>
                {
                    new() {Operator = "=", Type = "ERROR", Enabled = true, Id = 1, Key = "", Value = ""},
                    new() {Operator = "=", Type = "RESPONSE_CODE", Enabled = true, Id = 2, Key = "", Value = "200"},
                    new() {Operator = "<", Type = "METRIC", Enabled = true, Id = 3, Key = "synthetics.time.response", Value = "20000"}
                },
                Enabled = true,
                Interval = intervalInMinutes.ToString().Remove(0,1),
                Locations = new List<int>(){1},
                Method = method.ToString(),
                Name = name
            };
            var url = $"https://apps.eu.sematext.com/synthetics-api/api/apps/{appId}/monitors/http";
            var body = JsonConvert.SerializeObject(request);
            var result = await requestSender.SendRequest(url, HttpMethod.Post, body);

            return Utilities.JsonPrettify(result.Value);
        }
    }
}