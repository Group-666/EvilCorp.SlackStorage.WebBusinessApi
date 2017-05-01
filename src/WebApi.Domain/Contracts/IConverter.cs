using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace WebApi.Domain.Contracts
{
    public interface IConverter
    {
        string ConvertXmlToString(string xml);

        XDocument ConvertCreateJsonToXml(JObject json);
    }
}