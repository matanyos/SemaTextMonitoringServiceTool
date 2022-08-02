namespace SemaTextMonitoringServiceTool.DTOs
{
    public class Result
    {
        public Result(bool success, string value, string errorMessage)
        {
            Success = success;
            Value = value;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; }
        public string Value { get; }
        public string ErrorMessage { get; }
    }

}
