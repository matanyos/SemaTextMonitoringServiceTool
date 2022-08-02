using SemaTextMonitoringServiceTool.DTOs;

namespace SemaTextMonitoringServiceTool.Interfaces
{
    public interface ISemaTextHttpMonitorService
    {
        Task<string> CreateNewEndPointHttpMonitor(string name, string endpoint, string appId, HttpMethod method,
            Interval intervalInMinutes);

        Task<string> GetEndPointHttpMonitorStatus(string endpointName, string appId);
    }
}
