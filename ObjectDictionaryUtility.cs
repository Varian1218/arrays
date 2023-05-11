using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpBoosts
{
    public static class ObjectDictionaryUtility
    {
        public static ObjectDictionary<T> ToObjectDictionary<T>(
            this IEnumerable<(string Hash, T Object)> elements)
        {
            return new ObjectDictionary<T>
            {
                Objects = elements.ToDictionary(it => it.Hash, it => it.Object)
            };
        }

        public static ObjectDictionary<T> ToObjectDictionary<T>(
            this IEnumerable<T> elements,
            Func<T, string> keySelector
        )
        {
            return new ObjectDictionary<T>
            {
                Objects = elements.ToDictionary(keySelector)
            };
        }

        public static ObjectDictionary<TValue> ToObjectDictionary<T, TValue>(
            this IEnumerable<T> elements,
            Func<T, string> keySelector,
            Func<T, TValue> valueSelector
        )
        {
            return new ObjectDictionary<TValue>
            {
                Objects = elements.ToDictionary(keySelector, valueSelector)
            };
        }
    }
}