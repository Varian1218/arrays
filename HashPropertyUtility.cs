using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpBoosts
{
    public static class HashPropertyUtility
    {
        public static IEnumerable<(string Hash, PropertyInfo Info)> GetProperties<T>()
        {
            return GetProperties(typeof(T));
        }

        public static IEnumerable<(string Hash, PropertyInfo Info)> GetProperties(Type type)
        {
            return GetProperties<HashPropertyAttribute>(type).Select(it => (it.Attribute.Hash, it.Info));
        }

        public static IEnumerable<(TAttribute Attribute, PropertyInfo Info)> GetProperties<TAttribute>(Type type)
            where TAttribute : Attribute
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Select(it => (it.GetCustomAttribute<TAttribute>(), it))
                .Where(it => it.Item1 != null);
        }
    }
}