using Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Conditions;

namespace Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Services
{
    public interface IXmlAttributeBuilder
    {
        IXmlElementBuilder BuildAttribute();

        IXmlAttributeBuilder WithAttributeValue(object value);

        IXmlAttributeBuilder WithCondition(XmlBuildingCondition condition);
    }
}