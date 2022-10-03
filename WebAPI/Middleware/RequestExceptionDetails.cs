namespace ASPApp.WebAPI.Middleware
{
    public class RequestExceptionDetails
    {
        public int StatusCode { get; }
        public string? Message { get; }
        public string? ExceptionType { get; set; }

        public RequestExceptionDetails(int statusCode, string? message = null, string? exceptionType = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            ExceptionType = exceptionType;
        }

        private static string? GetDefaultMessageForStatusCode(int statusCode) => statusCode switch
        {
            401 => "Resource unavailable for unauthorised users",
            403 => "Resource unavailable for this user",
            404 => "Resource not found",
            500 => "An unhandled error occurred",
            _ => null,
        };

        public override string ToString()
        {
            return StatusCode + " " + Message + " " + ExceptionType;
        }
    }
}

