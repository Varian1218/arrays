using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpBoosts
{
    public static class EnumerableUtility
    {
        public delegate bool TryGetValue<T>(T key, out T value);

        public static IEnumerable<T> Select<T>(IEnumerable<T> source, TryGetValue<T> trySelector)
        {
            return source.Select(it => trySelector(it, out var value) ? value : it);
        }

        public static IEnumerable<TDes> SelectNotNull<TDes, T>(this IEnumerable<T> source, Func<T, TDes> selector)
        {
            return source.Select(selector).Where(result => result != null);
        }
    }
}