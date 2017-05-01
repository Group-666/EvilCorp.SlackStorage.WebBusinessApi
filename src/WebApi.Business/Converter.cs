using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApi.Domain.Contracts;

namespace WebApi.Business
{
    public class Converter : IConverter
    {
        public string ConvertXmlToString(string xml)
        {
            var doc = XDocument.Parse(xml);
            return JsonConvert.SerializeXNode(doc, Formatting.None, true);
        }

        public XDocument ConvertCreateJsonToXml(JObject json)
        {
            var xmlIn = JsonConvert.DeserializeXNode(json.ToString(), "User");
            return new XDocument(new XElement("RegisterUser", xmlIn.Root));
        }
    }
}