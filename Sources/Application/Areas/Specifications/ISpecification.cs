using System;
using System.Linq.Expressions;
using Mmu.Mlh.LanguageExtensions.Areas.ModelAbstractions;

namespace Mmu.Mlh.LanguageExtensions.Areas.Specifications
{
    public interface ISpecification<T>
        where T : AggregateRoot
    {
        bool IsSatisfiedBy(T aggregateRoot);

        Expression<Func<T, bool>> ToExpression();
    }
}