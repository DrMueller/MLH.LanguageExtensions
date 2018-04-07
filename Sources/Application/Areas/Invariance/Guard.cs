using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance.Handlers;

namespace Mmu.Mlh.LanguageExtensions.Areas.Invariance
{
    public static class Guard
    {
        private const string CollectionNullorEmptyMessage = "Collection {0} must not be null or empty.";
        private const string NullObjectExceptionMessage = "Object {0} must not be null.";
        private const string StringNullOrEmptyExceptionMessage = "String {0} must not be null or empty.";

        public static void CollectionNotNullOrEmpty<T>(Expression<Func<IEnumerable<T>>> propertyExpression)
        {
            var func = propertyExpression.Compile();
            var collection = func();

            if (collection != null && collection.Any())
            {
                return;
            }

            ThrowException(CollectionNullorEmptyMessage, propertyExpression);
        }

        public static void ObjectNotNull(Expression<Func<object>> propertyExpression)
        {
            var func = propertyExpression.Compile();
            var obj = func();

            if (obj != null)
            {
                return;
            }

            ThrowException(NullObjectExceptionMessage, propertyExpression);
        }

        public static void StringNotNullOrEmpty(Expression<Func<string>> propertyExpression)
        {
            var func = propertyExpression.Compile();
            var stringValue = func();

            if (!string.IsNullOrEmpty(stringValue))
            {
                return;
            }

            ThrowException(StringNullOrEmptyExceptionMessage, propertyExpression);
        }

        private static void ThrowException<T>(string exceptionMessageShell, Expression<Func<T>> propertyExpression)
        {
            var propertyName = ExpressionHandler.GetPropertyName(propertyExpression);
            var exceptionMessage = string.Format(exceptionMessageShell, propertyName);

            throw new ArgumentException(exceptionMessage);
        }
    }
}