using System.Net;

namespace ASPApp.Common.Exceptions
{
    public class EntryAlreadyExistsException : ApiException
    {
        public EntryAlreadyExistsException(string message) : base(HttpStatusCode.BadRequest, message) { }
    }
}
