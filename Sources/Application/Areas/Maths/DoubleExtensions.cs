using System;
using System.Collections.Generic;

namespace Mmu.Mlh.LanguageExtensions.Areas.Maths
{
    public static class DoubleExtensions
    {
        public static double Add(this double value, double valueToADd)
        {
            var mydecimal1 = new decimal(value);
            var mydecimal2 = new decimal(valueToADd);
            var res = decimal.Add(mydecimal1, mydecimal2);

            return decimal.ToDouble(res);
        }

        public static double Add(this double? value, double? valueToAdd)
        {
            var mydecimal1 = new decimal(value ?? 0.0);
            var mydecimal2 = new decimal(valueToAdd ?? 0.0);
            var res = decimal.Add(mydecimal1, mydecimal2);

            return decimal.ToDouble(res);
        }

        public static double Aggregate(this List<double?> list)
        {
            var res = new decimal(0);

            foreach (var myDouble in list)
            {
                var mydecimal2 = new decimal(myDouble ?? 0.0);
                res = decimal.Add(res, mydecimal2);
            }

            return decimal.ToDouble(res);
        }

        public static double Divide(this double value, double valueToDivide)
        {
            var mydecimal1 = new decimal(value);
            var mydecimal2 = new decimal(valueToDivide);

            return decimal.ToDouble(Divide(mydecimal1, mydecimal2));
        }

        public static double Divide(this double? value, double? value2)
        {
            var mydecimal1 = new decimal(value ?? 0.0);
            var mydecimal2 = new decimal(value2 ?? 0.0);

            return decimal.ToDouble(Divide(mydecimal1, mydecimal2));
        }

        public static bool IsEqual(this double value, double value2)
        {
            var mydecimal1 = new decimal(value);
            var mydecimal2 = new decimal(value2);

            return mydecimal1 == mydecimal2;
        }

        public static bool IsEqual(this double? value, double? value2)
        {
            var mydecimal1 = new decimal(value ?? 0.0);
            var mydecimal2 = new decimal(value2 ?? 0.0);

            return mydecimal1 == mydecimal2;
        }

        public static double Multiply(this double value, double value2)
        {
            var mydecimal1 = new decimal(value);
            var mydecimal2 = new decimal(value2);
            var res = decimal.Multiply(mydecimal1, mydecimal2);

            return decimal.ToDouble(res);
        }

        public static double Multiply(this double? value, double? value2)
        {
            var mydecimal1 = new decimal(value ?? 0.0);
            var mydecimal2 = new decimal(value2 ?? 0.0);
            var res = decimal.Multiply(mydecimal1, mydecimal2);

            return decimal.ToDouble(res);
        }

        public static double RoundWith0Digits(this double value)
        {
            return RoundWithDigits(value, 0);
        }

        public static double RoundWith2Digits(this double value)
        {
            return RoundWithDigits(value, 2);
        }

        public static double RoundWith3Digits(this double value)
        {
            return RoundWithDigits(value, 3);
        }

        public static double Subtract(this double value, double value2)
        {
            var mydecimal1 = new decimal(value);
            var mydecimal2 = new decimal(value2);
            var res = decimal.Subtract(mydecimal1, mydecimal2);

            return decimal.ToDouble(res);
        }

        public static double Subtract(this double? value, double? value2)
        {
            var mydecimal1 = new decimal(value ?? 0.0);
            var mydecimal2 = new decimal(value2 ?? 0.0);
            var res = decimal.Subtract(mydecimal1, mydecimal2);

            return decimal.ToDouble(res);
        }

        private static decimal Divide(decimal value1, decimal value2)
        {
            if (value2.Equals(0))
            {
                return new decimal(0);
            }

            return decimal.Divide(value1, value2);
        }

        private static double RoundWithDigits(double value, int digits)
        {
            if (double.IsNaN(value))
            {
                return 0.0;
            }

            var unroundedDecimal = new decimal(value);
            var roundedDecimal = Math.Round(unroundedDecimal, digits, MidpointRounding.AwayFromZero);

            return decimal.ToDouble(roundedDecimal);
        }
    }
}