using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpBoosts
{
    public static class AttributeUtility
    {
        public static IEnumerable<(string Hash, Type Type)> GetHashTypes<T>(this IEnumerable<Type> types)
            where T : Attribute, IHashObject
        {
            return types.Select(type => (Attribute: type.GetCustomAttribute<T>(), type))
                .Where(it => it.Attribute != null).Select(it => (it.Attribute.Hash, it.type));
        }

        public static bool TryGetAttribute<T>(this MemberInfo memberInfo, out T attribute) where T : Attribute
        {
            attribute = memberInfo.GetCustomAttribute<T>();
            return attribute != null;
        }
    }
}