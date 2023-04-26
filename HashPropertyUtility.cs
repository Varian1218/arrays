using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpBoosts
{
    public static class HashPropertyUtility
    {
        public static IEnumerable<(string, PropertyInfo)> GetProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Select(it => (it.GetCustomAttribute<HashPropertyAttribute>()?.Hash, it))
                .Where(it => !string.IsNullOrEmpty(it.Hash));
        }
    }
}