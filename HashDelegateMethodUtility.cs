using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CSharpBoosts
{
    public class HashDelegateMethodUtility
    {
        public static Dictionary<string, Delegate> GetMethods<T, TValue>(T t)
        {
            return HashMethodUtility.GetMethods(t.GetType()).ToValues(it =>
            {
                var delegateType = Expression.GetDelegateType(
                    it.GetParameters()
                        .Select(p => p.ParameterType)
                        .Concat(new[] { it.ReturnType })
                        .ToArray());
                return Delegate.CreateDelegate(delegateType, t, it);
            });
        }
    }
}