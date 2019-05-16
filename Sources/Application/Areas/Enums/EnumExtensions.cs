using System;
using System.Collections.Generic;
using System.Linq;

namespace Mmu.Mlh.LanguageExtensions.Areas.Enums
{
    public static class EnumExtensions
    {
        public static T GetAttribute<T>(this Enum targetEnum)
            where T : Attribute
        {
            var type = targetEnum.GetType();

            var memberInfo = type.GetMember(targetEnum.ToString());

            if (memberInfo.Length <= 0)
            {
                throw new ArgumentException("Enum members not found.");
            }

            var attrs = memberInfo[0].GetCustomAttributes(typeof(T), false);

            if (attrs.Length > 0)
            {
                return (T)attrs[0];
            }

            throw new ArgumentException("Could not find Attribute value.");
        }

        public static IEnumerable<T> GetValues<T>()
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException($"TEnum ({typeof(T).Name}) is not an enumeration type.");
            }

            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static bool TryParse<TEnum>(int value, out TEnum result)
            where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException($"TEnum ({typeof(TEnum).Name}) is not an enumeration type.");
            }

            // Note that Enum.TryParse only returns false if unable to convert the value, not if the value isn't defined as an underlying enum value.
            return Enum.TryParse(value.ToString(), out result) && Enum.IsDefined(typeof(TEnum), value);
        }
    }
}