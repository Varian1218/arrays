using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpBoosts
{
    public static class ObjectDatabaseUtility
    {
        public static string GetHash(Type type)
        {
            return type.FullName;
        }

        public static IEnumerable<TObject> Query<TObject>(
            this IObjectDatabase<TObject> database,
            Type type,
            TypeDictionary types
        )
        {
            return database.Query(types.GetKeyIfNotExits(type));
        }

        public static IEnumerable<T> Query<T>(
            this IObjectDatabase database,
            Type type,
            TypeDictionary types
        )
        {
            return database.Query<T>(GetHash(types.GetKeyIfNotExits(type)));
        }
        
        public static IObjectDatabase<T> SelectDatabase<T>(
            this IEnumerable<KeyValuePair<string, IEnumerable<T>>> objects
        )
        {
            return new ObjectDatabase<T>
            {
                Objects = objects.Select(it => (it.Key, it.Value))
            };
        }

        public static IObjectDatabase<T> SelectDatabase<T>(this IEnumerable<(string, IEnumerable<T>)> objects)
        {
            return new ObjectDatabase<T>
            {
                Objects = objects
            };
        }

        public static IObjectDatabase<T> SelectDatabase<T>(
            this IEnumerable<IEnumerable<(string, IEnumerable<T>)>> objects)
        {
            return new ObjectDatabase<T>
            {
                Objects = objects.SelectMany(it => it)
            };
        }

        public static IObjectDatabase<T> SelectDatabase<T>(
            this IEnumerable<(Type Type, IEnumerable<T> Objects)> objects)
        {
            return new ObjectDatabase<T>
            {
                Objects = objects.Select(it => (GetHash(it.Type), it.Objects))
            };
        }
    }
}