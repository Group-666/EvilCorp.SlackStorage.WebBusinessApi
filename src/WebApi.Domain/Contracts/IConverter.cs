using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace WebApi.Domain.Contracts
{
    public interface IConverter
    {
        T JsonToObject<T>(JObject body);

        JObject ObjectToJson<T>(T request);

        Guid StringToGuid(string userId);
    }
}