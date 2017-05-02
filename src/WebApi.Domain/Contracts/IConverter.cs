using System.Xml.Linq;
using EvilCorp.AccountService;
using Newtonsoft.Json.Linq;

namespace WebApi.Domain.Contracts
{
    public interface IConverter
    {
        string ConvertXmlToString(string xml);

        XDocument ConvertCreateJsonToXml(JObject json);

        Account JsonToAccount(JObject json);

        JObject AccountToJson(Account response);
    }
}