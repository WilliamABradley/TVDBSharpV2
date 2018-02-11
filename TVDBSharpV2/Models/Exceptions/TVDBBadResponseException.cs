using System;
using System.Net;

namespace TVDBSharp.Models.Exceptions
{
    /// <summary>
    /// The TVDB API responded with an Error.
    /// </summary>
    public class TVDBBadResponseException : Exception
    {
        /// <summary>
        /// Http Status Code of Response.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        internal TVDBBadResponseException(HttpStatusCode statusCode, string message = "Bad response", Exception inner = null)
            : base(message, inner)
        {
            StatusCode = statusCode;
        }
    }
}