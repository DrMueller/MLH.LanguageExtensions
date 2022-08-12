using Lamar;
using Mmu.Mlh.LanguageExtensions.Areas.Reflection.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Reflection.Services.Implementation;
using Mmu.Mlh.LanguageExtensions.Areas.Strings.StringCutting.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Strings.StringCutting.Services.Implementation;
using Mmu.Mlh.LanguageExtensions.Areas.Xml.XmlBuilding.Services;

namespace Mmu.Mlh.LanguageExtensions.Infrastructure.DependencyInjection
{
    public class LanguageExtensionsRegistryCollection : ServiceRegistry
    {
        public LanguageExtensionsRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<LanguageExtensionsRegistryCollection>();
                    scanner.WithDefaultConventions();
                    scanner.ExcludeType<IXmlElementBuilder>();
                    scanner.ExcludeType<IXmlAttributeBuilder>();
                });

            // Type reflection
            For<ITypeReflectionService>().Use<TypeReflectionService>();

            // StringCutting
            For<IStringCutterFactory>().Use<StringCutterFactory>().Singleton();
        }
    }
}