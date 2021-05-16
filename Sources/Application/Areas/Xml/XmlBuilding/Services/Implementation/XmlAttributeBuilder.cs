using System.Xml.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Conditions;

namespace Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Services.Implementation
{
    public class XmlAttributeBuilder : IXmlAttributeBuilder
    {
        private readonly string _attributeName;
        private readonly XElement _element;
        private readonly IXmlElementBuilder _xmlElementBuilder;
        private XmlBuildingCondition _condition;
        private object _value;

        public XmlAttributeBuilder(IXmlElementBuilder xmlElementBuilder, XElement element, string attributeName)
        {
            Guard.StringNotNullOrEmpty(() => attributeName);
            Guard.ObjectNotNull(() => xmlElementBuilder);
            Guard.ObjectNotNull(() => element);

            _xmlElementBuilder = xmlElementBuilder;
            _element = element;
            _attributeName = attributeName;
        }

        public IXmlElementBuilder BuildAttribute()
        {
            if (_condition != null && !_condition.CheckIfSatisfiedBy(_value))
            {
                return _xmlElementBuilder;
            }

            var xmlAttribute = new XAttribute(_attributeName, _value);
            _element.Add(xmlAttribute);

            return _xmlElementBuilder;
        }

        public IXmlAttributeBuilder WithAttributeValue(object value)
        {
            _value = value;

            return this;
        }

        public IXmlAttributeBuilder WithCondition(XmlBuildingCondition condition)
        {
            _condition = condition;

            return this;
        }
    }
}