using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Mmu.Mlh.LanguageExtensions.Areas.Invariance.Handlers
{
    internal static class ExpressionHandler
    {
        internal static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            var memberExpression = GetMemberExpression(propertyExpression);
            var result = memberExpression.Member.Name;

            return result;
        }

        [SuppressMessage("Microsoft.Usage", "SA1119:StatementMustNotUseUnnecessaryParenthesis", Justification = "Actually needed")]
        private static MemberExpression GetMemberExpression<T>(Expression<Func<T>> propertyExpression)
        {
            if (!(propertyExpression.Body is MemberExpression result))
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }

            return result;
        }
    }
}