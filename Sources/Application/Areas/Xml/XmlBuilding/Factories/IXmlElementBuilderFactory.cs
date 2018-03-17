using System.Xml.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Services;

namespace Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Factories
{
    public interface IXmlElementBuilderFactory
    {
        IXmlElementBuilder CreateTopLevelElement(XName elementName);
    }
}