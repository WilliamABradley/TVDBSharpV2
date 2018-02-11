using System;

namespace TVDBSharp.Models.Exceptions
{
    /// <summary>
    /// An exception that occurs when the TVDB API server was not available to process the request.
    /// </summary>
    public class TVDBNotAvailableException : Exception
    {
        internal TVDBNotAvailableException(string message = "Server is currently not available. Please try again later", Exception inner = null)
            : base(message, inner)
        {
        }
    }
}