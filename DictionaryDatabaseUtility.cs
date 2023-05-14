using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpBoosts
{
    public static class DictionaryDatabaseUtility
    {
        public static string GetHash(Type type)
        {
            return type.FullName;
        }

        public static IDictionary<string, T> Query<T>(this IDictionaryDatabase database)
        {
            return database.Query<string, T>();
        }

        public static IDictionary<TKey, TValue> Query<TKey, TValue>(this IDictionaryDatabase database)
        {
            return database.Query<TKey, TValue>(typeof(TValue));
        }

        public static IDictionary<TKey, TValue> Query<TKey, TValue>(this IDictionaryDatabase database, string hash)
        {
            return (IDictionary<TKey, TValue>)database.Query(hash);
        }

        public static IDictionary<TKey, TValue> Query<TKey, TValue>(this IDictionaryDatabase database, Type type)
        {
            return database.Query<TKey, TValue>(GetHash(type));
        }

        public static IDictionary Query(this IDictionaryDatabase database, Type type)
        {
            return database.Query(GetHash(type));
        }

        public static DictionaryDatabase ToDictionaryDatabase<T>(
            this IEnumerable<(string Hash, IEnumerable<T> Objects)> source,
            IDictionary<string, Func<T, string>> keySelectors
        )
        {
            return new DictionaryDatabase
            {
                Objects = source.Where(it => keySelectors.ContainsKey(it.Hash))
                    .ToDictionary(
                        it => it.Hash,
                        it =>
                        {
                            var keySelector = keySelectors[it.Hash];
                            return (IDictionary)it.Objects.ToDictionary(obj => keySelector(obj));
                        }
                    )
            };
        }
    }
}