namespace TimeReportHH
{
    public class ApiResult
    {
        public string Message { get; set; }
        public object? Payload { get; set; }
        public ApiResult(string message, object? payload = null)
        {
            Message = message;
            Payload = payload;
        }
    }
}
