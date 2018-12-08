using System;
using System.Collections.Generic;
using System.Reflection;
using Mmu.Mlh.LanguageExtensions.Areas.DeepCopying.Servants;

namespace Mmu.Mlh.LanguageExtensions.Areas.DeepCopying.Implementation
{
    public static class DeepCopyService
    {
        private static readonly MethodInfo _cloneMethod = typeof(object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);

        public static T DeepCopy<T>(T source)
        {
            var equalityComparer = new DeepCopyReferenceEqualityComparer<T>();
            var visitedObjectsDict = new Dictionary<object, object>(equalityComparer);
            var copy = DeepCopy(source, visitedObjectsDict);
            return (T)copy;
        }

        private static bool CheckIfTypeIsPrimitive(Type type)
        {
            if (type == typeof(string))
            {
                return true;
            }

            return type.IsValueType & type.IsPrimitive;
        }

        private static void CopyFields(object originalObject, IDictionary<object, object> visited, object cloneObject, IReflect typeToReflect, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy, Func<FieldInfo, bool> filter = null)
        {
            foreach (var fieldInfo in typeToReflect.GetFields(bindingFlags))
            {
                if (filter != null && filter(fieldInfo) == false)
                {
                    continue;
                }

                if (CheckIfTypeIsPrimitive(fieldInfo.FieldType))
                {
                    continue;
                }

                var originalFieldValue = fieldInfo.GetValue(originalObject);
                var clonedFieldValue = DeepCopy(originalFieldValue, visited);
                fieldInfo.SetValue(cloneObject, clonedFieldValue);
            }
        }

        private static object DeepCopy(object originalObject, IDictionary<object, object> visited)
        {
            if (originalObject == null)
            {
                return null;
            }

            var typeToReflect = originalObject.GetType();
            if (CheckIfTypeIsPrimitive(typeToReflect))
            {
                return originalObject;
            }

            if (visited.ContainsKey(originalObject))
            {
                return visited[originalObject];
            }

            if (typeof(Delegate).IsAssignableFrom(typeToReflect))
            {
                return null;
            }

            var cloneObject = _cloneMethod.Invoke(originalObject, null);
            if (typeToReflect.IsArray)
            {
                var arrayType = typeToReflect.GetElementType();
                if (CheckIfTypeIsPrimitive(arrayType) == false)
                {
                    var clonedArray = (Array)cloneObject;
                    clonedArray.ForEach((array, indices) => array.SetValue(DeepCopy(clonedArray.GetValue(indices), visited), indices));
                }
            }

            visited.Add(originalObject, cloneObject);
            CopyFields(originalObject, visited, cloneObject, typeToReflect);
            RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect);
            return cloneObject;
        }

        private static void RecursiveCopyBaseTypePrivateFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect)
        {
            if (typeToReflect.BaseType == null)
            {
                return;
            }

            RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect.BaseType);
            CopyFields(originalObject, visited, cloneObject, typeToReflect.BaseType, BindingFlags.Instance | BindingFlags.NonPublic, info => info.IsPrivate);
        }
    }
}