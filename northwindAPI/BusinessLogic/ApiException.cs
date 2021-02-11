using System;
using System.Net;

namespace northwindAPI.BusinessLogic
{
    public class ApiException : Exception
    {
        public HttpStatusCode HttpStatusCode {get; set;}

        public ApiException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            this.HttpStatusCode = httpStatusCode;
        }
        public ApiException(HttpStatusCode httpStatusCode, string message, Exception innerException) : base(message, innerException)
        {
            this.HttpStatusCode = httpStatusCode;
        }
    }
}
