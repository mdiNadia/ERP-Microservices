using System.Net;

namespace Common.Infrastructure.Services.Errors
{
    public class RestException : Exception
    {
        public RestException(HttpStatusCode code, string errors = null)
        {
            Code = code;
            Error = errors;
        }

        public HttpStatusCode Code { get; }
        public string Error { get; }
    }
}
