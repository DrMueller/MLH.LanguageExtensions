using System.Xml.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Conditions;

namespace Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Services
{
    public interface IXmlElementBuilder
    {
        IXmlElementBuilder BuildElement();

        XElement FinishBuilding();

        IXmlElementBuilder StartBuildingChildElement(string elementName);

        IXmlAttributeBuilder WithAttribute(string name);

        IXmlElementBuilder WithCondition(XmlBuildingCondition condition);

        IXmlElementBuilder WithConditionAttribute(object value);

        IXmlElementBuilder WithElementValue(object value);
    }
}