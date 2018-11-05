using System.Collections.Generic;

namespace Mmu.Mlh.LanguageExtensions.Areas.DeepCopying.Handlers
{
    internal class DeepCopyReferenceEqualityComparer<T> : EqualityComparer<object>
    {
        public override bool Equals(object x, object y)
        {
            return ReferenceEquals(x, y);
        }

        public override int GetHashCode(object obj)
        {
            return obj?.GetHashCode() ?? 0;
        }
    }
}