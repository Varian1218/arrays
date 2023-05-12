using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpBoosts
{
    public static class TypeUtils
    {
        public static IEnumerable<Type> All =>
            AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes());

        public static IEnumerable<Type> StaticTypes => All.Where(IsStatic);

        public static IEnumerable<Type> AssignableWhere<T>(this IEnumerable<Type> types)
        {
            return types.Where(it => typeof(T).IsAssignableFrom(it));
        }

        public static string GetHash(this Type type)
        {
            return type.GetCustomAttribute<HashAttribute>().Hash;
        }

        public static IEnumerable<Type> InterfaceWhere<T>(this IEnumerable<Type> types, IEnumerable<Type> args)
        {
            return types.InterfaceTypeWhere(typeof(T), args);
        }

        public static IEnumerable<Type> InterfaceTypeWhere(
            this IEnumerable<Type> types,
            Type type,
            IEnumerable<Type> args
        )
        {
            return types.Where(it => it.GetInterfaces().Any(i => i.IsType(type, args)));
        }

        public static bool IsType(this Type type, Type definition, IEnumerable<Type> arguments)
        {
            return type.GetGenericTypeDefinition() == definition && type.GetGenericArguments().SequenceEqual(arguments);
        }

        public static bool IsStatic(this Type type)
        {
            return type.IsClass && type.IsAbstract && type.IsSealed;
        }
    }
}