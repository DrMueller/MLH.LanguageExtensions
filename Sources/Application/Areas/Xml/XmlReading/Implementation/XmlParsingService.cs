using System;
using System.Linq;
using System.Xml.Linq;

namespace Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlReading.Implementation
{
    public class XmlParsingService : IXmlParsingService
    {
        public T ParseSubElementValue<T>(XElement element, string subElementLocalName)
            where T : struct
        {
            return TryParsingSubElementValue<T>(element, subElementLocalName).Value;
        }

        public T TryParsingSubElementEnumValue<T>(XElement element, string subElementLocalName, T defaultValue)
        {
            var stringValue = TryParsingSubElementStringValue(element, subElementLocalName);

            if (string.IsNullOrEmpty(stringValue))
            {
                return defaultValue;
            }

            var enumValue = (T)Enum.Parse(typeof(T), stringValue, true);
            return enumValue;
        }

        public string TryParsingSubElementStringValue(XElement element, string subElementLocalName)
        {
            return TryGettingValueOfSubElement(element, subElementLocalName);
        }

        public T? TryParsingSubElementValue<T>(XElement element, string subElementLocalName)
            where T : struct
        {
            var stringValue = TryGettingValueOfSubElement(element, subElementLocalName);

            if (string.IsNullOrEmpty(stringValue))
            {
                return null;
            }

            var result = (T)Convert.ChangeType(stringValue, typeof(T));
            return result;
        }

        private static string TryGettingValueOfSubElement(XContainer element, string subElementLocalName)
        {
            var subElement = element.Descendants().FirstOrDefault(f => f.Name.LocalName == subElementLocalName);
            return subElement?.Value;
        }
    }
}