using System.Xml.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Services.Implementation;

namespace Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Factories.Implementation
{
    public class XmlElementBuilderFactory : IXmlElementBuilderFactory
    {
        public IXmlElementBuilder CreateTopLevelElement(XName elementName)
        {
            return new XmlElementBuilder(null!, null!, elementName);
        }
    }
}