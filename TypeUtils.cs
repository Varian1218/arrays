using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpBoosts
{
    public static class TypeUtils
    {
        public static IEnumerable<Type> All =>
            AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes());
    }
}