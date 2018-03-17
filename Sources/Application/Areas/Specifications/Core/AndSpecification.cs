using System;
using System.Linq.Expressions;
using Mmu.Mlh.LanguageExtensions.Areas.ModelAbstractions;
using Mmu.Mlh.LanguageExtensions.Areas.Specifications.Core.Handlers;

namespace Mmu.Mlh.LanguageExtensions.Areas.Specifications.Core
{
    public sealed class AndSpecification<T> : SpecificationBase<T>
        where T : AggregateRoot
    {
        private readonly SpecificationBase<T> _left;
        private readonly SpecificationBase<T> _right;

        public AndSpecification(SpecificationBase<T> left, SpecificationBase<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }
}