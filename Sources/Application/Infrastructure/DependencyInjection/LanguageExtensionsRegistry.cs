using Mmu.Mlh.LanguageExtensions.Areas.Reflection;
using Mmu.Mlh.LanguageExtensions.Areas.Reflection.Implementation;
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
                });

            For<ITypeReflectionService>().Use<TypeReflectionService>();
        }
    }
}