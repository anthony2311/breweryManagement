using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Domain.Exceptions
{
    /// <summary>
    /// Exception used to return proper HTTP response
    /// Web api must use actionFilter to properly manage the exception
    /// </summary>
    public class HttpResponseException : Exception
    {
        public HttpResponseException(HttpStatusCode statusCode, string message)
        {
            Status = ((int)statusCode);
            Value = message;
        }
        public int Status { get; set; } = 500;

        public object Value { get; set; }
    }
}
