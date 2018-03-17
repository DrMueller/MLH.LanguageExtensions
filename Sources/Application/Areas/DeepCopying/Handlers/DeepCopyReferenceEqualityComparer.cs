using System.Collections.Generic;

namespace Mmu.Mlh.LanguageExtensions.Areas.DeepCopying.Handlers
{
    internal class DeepCopyReferenceEqualityComparer<T> : EqualityComparer<object>
    {
        public override bool Equals(object x, object y) => ReferenceEquals(x, y);

        public override int GetHashCode(object obj) => obj?.GetHashCode() ?? 0;
    }
}