using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Conditions;

namespace Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Services.Implementation
{
    public class XmlElementBuilder : IXmlElementBuilder
    {
        private readonly XElement _element;
        private readonly XElement _parent;
        private readonly IXmlElementBuilder _parentElementBuilder;
        private XmlBuildingCondition? _condition;
        private object? _value;

        internal XmlElementBuilder(XElement parent, IXmlElementBuilder parentElementBuilder, XName elementName)
        {
            _value = null;
            _parent = parent;
            _parentElementBuilder = parentElementBuilder;
            _element = new XElement(elementName);
        }

        [SuppressMessage(
            "Microsoft.Usage",
            "SA1119:StatementMustNotUseUnnecessaryParenthesis",
            Justification = "Actually needed")]
        public IXmlElementBuilder BuildElement()
        {
            if (_condition != null && !_condition.CheckIfSatisfiedBy(_value))
            {
                return _parentElementBuilder;
            }

            if (!_element.HasElements)
            {
                if (_value != null && (!(_value is string str) || !string.IsNullOrEmpty(str)))
                {
                    _element.SetValue(_value);
                }
            }

            _parent.Add(_element);

            return _parentElementBuilder;
        }

        public XElement FinishBuilding()
        {
            return _element;
        }

        public IXmlElementBuilder StartBuildingChildElement(string elementName)
        {
            return new XmlElementBuilder(_element, this, elementName);
        }

        public IXmlAttributeBuilder WithAttribute(string name)
        {
            return new XmlAttributeBuilder(this, _element, name);
        }

        public IXmlElementBuilder WithCondition(XmlBuildingCondition condition)
        {
            _condition = condition;

            return this;
        }

        public IXmlElementBuilder WithConditionAttribute(object value)
        {
            new XmlAttributeBuilder(this, _element, "Condition")
                .WithAttributeValue(value)
                .BuildAttribute();

            return this;
        }

        public IXmlElementBuilder WithElementValue(object value)
        {
            _value = value;

            return this;
        }
    }
}