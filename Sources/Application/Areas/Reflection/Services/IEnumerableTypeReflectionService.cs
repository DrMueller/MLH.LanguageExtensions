using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.Reflection.Services
{
    public interface IEnumerableTypeReflectionService
    {
        Type GetGenericTypeOfIEnumerable(object genericEnumerable);
    }
}