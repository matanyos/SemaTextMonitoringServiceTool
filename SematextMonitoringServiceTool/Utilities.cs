using Newtonsoft.Json;
using SemaTextMonitoringServiceTool.DTOs;

namespace SemaTextMonitoringServiceTool
{
    public static class Utilities
    {
        public static string TryGetValue(string title)
        {
            Console.WriteLine(title);
            var input = Console.ReadLine();

            return string.IsNullOrEmpty(input)
                ? TryGetValue(title)
                : input;
        } 
        public static string JsonPrettify(string json)
        {
            using var stringReader = new StringReader(json);
            using var stringWriter = new StringWriter();
            var jsonReader = new JsonTextReader(stringReader);
            var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
            jsonWriter.WriteToken(jsonReader);
            return stringWriter.ToString();
        }
        public static HttpMethod TryGetHttpMethodValue()
        {
            var method = HttpMethod.Get;
            var input = TryGetValue("Http Method: ");
            if (input.Equals("get", StringComparison.OrdinalIgnoreCase))
            {
                method = HttpMethod.Get;
            }
            else if (input.Equals("post", StringComparison.OrdinalIgnoreCase))
            {
                method = HttpMethod.Post;
            }
            else if (input.Equals("delete", StringComparison.OrdinalIgnoreCase))
            {
                method = HttpMethod.Delete;
            }
            else if (input.Equals("put", StringComparison.OrdinalIgnoreCase))
            {
                method = HttpMethod.Put;
            }
            else
            {
                TryGetHttpMethodValue();
            }

            return method;
        }
        public static Interval TryGetIntervalValue()
       {
           var interval = Interval._1m;
           var input = TryGetValue("Interval: ");
           if (input.Equals("1", StringComparison.OrdinalIgnoreCase))
           {
               interval = Interval._1m;
           }
           else if (input.Equals("5", StringComparison.OrdinalIgnoreCase))
           {
               interval = Interval._5m;
           }
           else if (input.Equals("10", StringComparison.OrdinalIgnoreCase))
           {
               interval = Interval._10m;
           }
           else if (input.Equals("15", StringComparison.OrdinalIgnoreCase))
           {
               interval = Interval._15m;
           }
           else
           {
               TryGetIntervalValue();
           }

           return interval;
       }
    }
}
