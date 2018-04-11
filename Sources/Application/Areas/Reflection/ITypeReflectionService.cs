using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.Reflection
{
    public interface ITypeReflectionService
    {
        bool CheckIfTypeIsAssignableToGenericType(Type givenType, Type genericType);
    }
}