using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Mmu.Mlh.LanguageExtensions.Areas.Reflection.Extensions
{
    public static class PropertyExtensions
    {
        public static string GetPropertyName<T, TProperty>(Expression<Func<T, TProperty>> expression)
        {
            if (expression.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            if (expression.Body is UnaryExpression unaryExpression)
            {
                memberExpression = unaryExpression.Operand as MemberExpression;
                if (memberExpression == null)
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                throw new NotImplementedException();
            }

            return memberExpression.Member.Name;
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "owner", Justification = "Extension Method: Implicitly takes type of owner!")]
        public static string GetPropertyName<T, TField>(this T owner, Expression<Func<T, TField>> expression) => GetPropertyName(expression);
    }
}