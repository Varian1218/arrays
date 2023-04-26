using System;
using System.Reflection;

namespace CSharpBoosts
{
    public static class DelegateUtility
    {
        public static T CreateDelegate<T>(object firstArgument, MethodInfo methodInfo) where T : Delegate
        {
            return (T)Delegate.CreateDelegate(typeof(T), firstArgument, methodInfo);
        }
    }
}