namespace ErrorHandling.Models
{
    public class ErrorModel
    {
        public ErrorModel(string message)
        {
            Message = message;
        }

        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; }
    }
}
