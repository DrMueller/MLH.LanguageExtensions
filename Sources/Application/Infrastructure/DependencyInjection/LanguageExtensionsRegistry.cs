using Mmu.Mlh.LanguageExtensions.Areas.Reflection.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Reflection.Services.Implementation;
using Mmu.Mlh.LanguageExtensions.Areas.Strings.StringCutting.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Strings.StringCutting.Services.Implementation;
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

            // Type reflection
            For<ITypeReflectionService>().Use<TypeReflectionService>();

            // StringCutting
            For<IStringCutterFactory>().Use<StringCutterFactory>().Singleton();
        }
    }
}