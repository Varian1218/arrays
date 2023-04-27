using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpBoosts
{
    public static class HashMethodUtility
    {
        public static IEnumerable<(string, MethodInfo)> GetMethods(Type type)
        {
            return type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Select(it => (it.GetCustomAttribute<HashPropertyAttribute>()?.Hash, it))
                .Where(it => !string.IsNullOrEmpty(it.Hash));
        }
    }
}