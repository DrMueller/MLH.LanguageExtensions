using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.DeepCopying.Servants
{
    internal static class DeepCopyArrayExtensions
    {
        public static void ForEach(this Array array, Action<Array, int[]> action)
        {
            if (array.LongLength == 0)
            {
                return;
            }

            var walker = new DeepCopyArrayTraverse(array);

            do
            {
                action(array, walker.Position);
            }
            while (walker.Step());
        }
    }
}