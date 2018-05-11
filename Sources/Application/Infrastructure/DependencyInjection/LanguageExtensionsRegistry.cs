using Mmu.Mlh.LanguageExtensions.Areas.Reflection.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Reflection.Services.Implementation;
using Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Services.Implementation;
using StructureMap;

namespace Mmu.Mlh.LanguageExtensions.Infrastructure.DependencyInjection
{
    public class LanguageExtensionsRegistry : Registry
    {
        public LanguageExtensionsRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<LanguageExtensionsRegistry>();
                    scanner.WithDefaultConventions();
                    scanner.ExcludeType<XmlElementBuilder>();
                    scanner.ExcludeType<XmlAttributeBuilder>();
                });

            For<ITypeReflectionService>().Use<TypeReflectionService>();
        }
    }
}