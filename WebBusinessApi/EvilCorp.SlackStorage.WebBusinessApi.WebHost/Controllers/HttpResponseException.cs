using System;
using System.Net.Http;

namespace EvilCorp.SlackStorage.WebBusinessApi.WebHost.Controllers
{
    [Serializable]
    internal class HttpResponseException : Exception
    {
        private HttpResponseMessage message;

        public HttpResponseException()
        {
        }

        public HttpResponseException(HttpResponseMessage message)
        {
            this.message = message;
        }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}