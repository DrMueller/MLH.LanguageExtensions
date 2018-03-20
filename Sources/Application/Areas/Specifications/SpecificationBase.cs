using System;
using System.Linq.Expressions;
using Mmu.Mlh.LanguageExtensions.Areas.DomainModels;
using Mmu.Mlh.LanguageExtensions.Areas.Specifications.Core;

namespace Mmu.Mlh.LanguageExtensions.Areas.Specifications
{
    public abstract class SpecificationBase<T> : ISpecification<T>
        where T : AggregateRoot
    {
        public SpecificationBase<T> And(SpecificationBase<T> specification) => new AndSpecification<T>(this, specification);

        public bool IsSatisfiedBy(T aggregateRoot)
        {
            var predicate = ToExpression().Compile();
            var result = predicate(aggregateRoot);

            return result;
        }

        public SpecificationBase<T> Not() => new NotSpecification<T>(this);

        public SpecificationBase<T> Or(SpecificationBase<T> specification) => new OrSpecification<T>(this, specification);

        public abstract Expression<Func<T, bool>> ToExpression();
    }
}