using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpExtensions
{
    public static class DictionaryUtility
    {
        public static Dictionary<TKey, TDes> ToValues<TDes, TKey, TSrc>(
            this IDictionary<TKey, TSrc> dictionary,
            Func<TSrc, TDes> transform
        )
        {
            return dictionary.ToDictionary(it => it.Key, it => transform(it.Value));
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> pairs
        )
        {
            return pairs.ToDictionary(it => it.Key, it => it.Value);
        }
    }
}