using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Serverspace.OpenApi.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public ApiException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
