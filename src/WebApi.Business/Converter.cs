using Newtonsoft.Json.Linq;
using System;
using WebApi.Domain.Contracts;

namespace WebApi.Business
{
    public class Converter : IConverter
    {
        private const string InvalidJsonError = "Invalid Json. Value: {0}";
        private const string InvalidGuidError = "Invalid GUID. Value: {0}";
        private const string ErrorDeserializing = "Deserializing error. Value: {0}";

        public T JsonToObject<T>(JObject body)
        {
            if (body == null)
                throw new ArgumentException(string.Format(InvalidJsonError, body), nameof(body));

            var result = body.ToObject<T>();

            if (result == null)
                throw new ArgumentException(string.Format(InvalidJsonError, body), nameof(body));

            return result;
        }

        public JObject ObjectToJson<T>(T request)
        {
            if (request == null)
                throw new ArgumentException(string.Format(ErrorDeserializing, request), nameof(request));

            var body = JObject.FromObject(request);

            if (body == null)
                throw new ArgumentException(string.Format(ErrorDeserializing, request), nameof(request));

            return body;
        }

        public Guid StringToGuid(string userId)
        {
            Guid guid;
            if (!Guid.TryParse(userId, out guid))
                throw new ArgumentException(string.Format(InvalidGuidError, userId), nameof(userId));

            return guid;
        }
    }
}