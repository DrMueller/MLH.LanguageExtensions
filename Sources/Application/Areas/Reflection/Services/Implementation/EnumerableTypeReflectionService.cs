using System;
using System.Collections.Generic;
using System.Linq;

namespace Mmu.Mlh.LanguageExtensions.Areas.Reflection.Services.Implementation
{
    public class EnumerableTypeReflectionService : IEnumerableTypeReflectionService
    {
        public Type GetGenericTypeOfIEnumerable(object genericEnumerable)
        {
            var types = genericEnumerable.GetType()
                .GetInterfaces()
                .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                .Select(t => t.GetGenericArguments()[0]).ToArray();

            if (types.Any())
            {
                return types[0];
            }

            return typeof(object);
        }
    }
}