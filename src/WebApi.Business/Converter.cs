using Newtonsoft.Json.Linq;
using System;
using WebApi.Domain.Contracts;

namespace WebApi.Business
{
    public class Converter : IConverter
    {
        private const string FieldNullOrEmptyError = "The field cannot be null or empty.";
        private const string InvalidJsonError = "Invalid Json. Value: {0}";
        private const string InvalidGuidError = "Invalid GUID. Value: {0}";
        private const string ErrorDeserializing = "Deserializing error. Value: {0}";

        public Guid StringToGuid(string userId)
        {
            Guid guid;
            if (!Guid.TryParse(userId, out guid))
                throw new ArgumentException(string.Format(InvalidGuidError, userId), nameof(userId));

            return guid;
        }

        public T JsonToObject<T>(JObject body)
        {
            if (body == null)
                throw new ArgumentException(FieldNullOrEmptyError, nameof(body));

            var result = body.ToObject<T>();
            if (result == null)
                throw new ArgumentException(string.Format(InvalidJsonError, body), nameof(body));

            return result;
        }

        public JObject ObjectToJson<T>(T request)
        {
            if (request == null)
                throw new ArgumentException(FieldNullOrEmptyError, nameof(request));

            var body = JObject.FromObject(request);

            if (body == null)
                throw new ArgumentException(string.Format(ErrorDeserializing, request), nameof(request));

            return body;
        }

        public JObject ObjectsToJson<T>(T request, string nameOfObjects = "objects")
        {
            if (request == null)
                throw new ArgumentException(FieldNullOrEmptyError, nameof(request));
            if (string.IsNullOrEmpty(nameOfObjects))
                throw new ArgumentException(FieldNullOrEmptyError, nameof(nameOfObjects));

            var body = new JObject { [nameOfObjects] = JToken.FromObject(nameOfObjects) };
            if (body == null)
                throw new ArgumentException(string.Format(ErrorDeserializing, request), nameof(request));

            return body;
        }

        public JObject StringToJson(string request)
        {
            if (string.IsNullOrEmpty(request))
                throw new ArgumentException(FieldNullOrEmptyError, nameof(request));

            var body = JObject.Parse(request);

            if (body == null)
                throw new ArgumentException(string.Format(ErrorDeserializing, request), nameof(request));

            return body;
        }
    }
}