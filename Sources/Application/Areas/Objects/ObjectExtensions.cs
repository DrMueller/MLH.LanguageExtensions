using System;
using System.Reflection;

namespace Mmu.Mlh.LanguageExtensions.Areas.Objects
{
    public static class ObjectExtensions
    {
        public static bool CheckIfAllPropertiesAreSet(this object item)
        {
            var allProperties = item.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var prop in allProperties)
            {
                var propValue = prop.GetValue(item);

                if (propValue is null)
                {
                    return false;
                }

                if (propValue is string str && string.IsNullOrEmpty(str))
                {
                    return false;
                }

                var propValueType = propValue.GetType();

                if (propValueType.IsPrimitive)
                {
                    var defaultValue = Activator.CreateInstance(propValue.GetType());

                    if (propValue.Equals(defaultValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}