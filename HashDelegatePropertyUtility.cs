using System.Collections.Generic;

namespace CSharpBoosts
{
    public static class HashDelegatePropertyUtility
    {
        public static Dictionary<string, DelegateProperty<T, TValue>> GetProperties<T, TValue>(T t)
        {
            return HashPropertyUtility.GetProperties(t.GetType())
                .ToValues(it => DelegatePropertyUtility.Create<T, TValue>(t, it));
        }
    }
}