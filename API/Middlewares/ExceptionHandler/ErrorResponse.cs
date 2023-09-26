namespace API.Middlewares.ExceptionHandler
{
    public class ErrorResponse
    {
        public string StackTrace { get;set; }

        public string Message { get; set; }

        public ErrorResponse(string message, string stackTrace)
        {
            StackTrace = stackTrace;

            Message = message;
        }
    }
}
