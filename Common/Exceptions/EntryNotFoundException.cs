using System.Net;

namespace ASPApp.Common.Exceptions
{
    public class EntryNotFoundException : ApiException
    {
        public EntryNotFoundException(string message) : base(HttpStatusCode.NotFound, message) { }
    }
}
