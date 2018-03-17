﻿using System;
using System.Linq.Expressions;
using Mmu.Mlh.LanguageExtensions.Areas.ModelAbstractions;
using Mmu.Mlh.LanguageExtensions.Areas.Specifications.Core.Handlers;

namespace Mmu.Mlh.LanguageExtensions.Areas.Specifications.Core
{
    public class NotSpecification<T> : SpecificationBase<T>
        where T : AggregateRoot
    {
        private readonly SpecificationBase<T> _spec;

        public NotSpecification(SpecificationBase<T> spec) => _spec = spec;

        public override Expression<Func<T, bool>> ToExpression()
        {
            var specExpression = _spec.ToExpression();

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.Not(specExpression.Body);

            var visitedExpr = new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(visitedExpr, paramExpr);

            return finalExpr;
        }
    }
}