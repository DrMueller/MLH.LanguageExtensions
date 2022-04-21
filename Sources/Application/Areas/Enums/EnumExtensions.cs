using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

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

        public static Maybe<TEnum> TryParse<TEnum>(int value)
            where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException($"TEnum ({typeof(TEnum).Name}) is not an enumeration type.");
            }

            var parseResult = Enum.TryParse<TEnum>(value.ToString(), out var result);

            // Note that Enum.TryParse only returns false if unable to convert the value, not if the value isn't defined as an underlying enum value.
            var isValidEnum = parseResult && Enum.IsDefined(typeof(TEnum), result);

            return isValidEnum ? Maybe.CreateSome(result) : Maybe.CreateNone<TEnum>();
        }
    }
}