using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SemaTextMonitoringServiceTool.DTOs;

namespace SemaTextMonitoringServiceTool
{
    public class RequestSender
    {
        private string? ApiKey { get; }
        public RequestSender(string? apiKey)
        {
            ApiKey = apiKey;
        }
        public async Task<Result> SendRequest(string url, HttpMethod method, string body)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", $"apiKey {ApiKey}");

            var httpRequestMessage = new HttpRequestMessage(method, url);

            if (body!=string.Empty)
                httpRequestMessage.Content = new StringContent(body, Encoding.UTF8, "application/json");

            var responseMessage = await client.SendAsync(httpRequestMessage);

            return responseMessage.IsSuccessStatusCode
                ? new Result(true, await responseMessage.Content.ReadAsStringAsync(), string.Empty)
                : new Result(false, responseMessage.StatusCode.ToString(), await responseMessage.Content.ReadAsStringAsync());
        }
    }
}
