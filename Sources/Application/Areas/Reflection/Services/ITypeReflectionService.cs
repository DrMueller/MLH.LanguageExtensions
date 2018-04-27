using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.Reflection.Services
{
    public interface ITypeReflectionService
    {
        bool CheckIfTypeIsAssignableToGenericType(Type givenType, Type genericType);
    }
}