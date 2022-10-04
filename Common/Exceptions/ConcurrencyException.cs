using System.Net;

namespace ASPApp.Common.Exceptions
{
    public class ConcurrencyException : ApiException
    {
        public ConcurrencyException(string message) : base(HttpStatusCode.Conflict, message) { }
    }
}
