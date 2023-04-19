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
    }
}