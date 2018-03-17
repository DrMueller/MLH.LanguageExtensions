using System.Xml.Linq;

namespace Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlReading
{
    public interface IXmlParsingService
    {
        T ParseSubElementValue<T>(XElement element, string subElementLocalName)
            where T : struct;

        T TryParsingSubElementEnumValue<T>(XElement element, string subElementLocalName, T defaultValue);

        string TryParsingSubElementStringValue(XElement element, string subElementLocalName);

        T? TryParsingSubElementValue<T>(XElement element, string subElementLocalName)
            where T : struct;
    }
}