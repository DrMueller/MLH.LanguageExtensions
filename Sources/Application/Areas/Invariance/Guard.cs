using System;
using System.Linq.Expressions;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance.Handlers;

namespace Mmu.Mlh.LanguageExtensions.Areas.Invariance
{
    public static class Guard
    {
        internal const string NullObjectExceptionMessage = "Object {0} must not be null.";
        internal const string StringNullOrEmptyExceptionMessage = "String {0} must not be null or empty.";

        public static void ObjectNotNull(Expression<Func<object>> propertyExpression)
        {
            var func = propertyExpression.Compile();
            var obj = func();

            if (obj != null)
            {
                return;
            }

            var propertyName = ExpressionHandler.GetPropertyName(propertyExpression);
            var exceptionMessage = string.Format(NullObjectExceptionMessage, propertyName);
            throw new ArgumentException(exceptionMessage);
        }

        public static void StringNotNullOrEmpty(Expression<Func<string>> propertyExpression)
        {
            var func = propertyExpression.Compile();
            var stringValue = func();

            if (!string.IsNullOrEmpty(stringValue))
            {
                return;
            }

            var propertyName = ExpressionHandler.GetPropertyName(propertyExpression);
            var exceptionMessage = string.Format(StringNullOrEmptyExceptionMessage, propertyName);
            throw new ArgumentException(exceptionMessage);
        }
    }
}