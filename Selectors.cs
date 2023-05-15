using System;

namespace CSharpBoosts
{
    public static class Selectors
    {
        public static readonly (Type, Delegate) Object = Selector<ObjectData>(data => data.Hash);

        public static (Type, Delegate) Selector<T>(Func<T, string> keySelector)
        {
            return (typeof(T), keySelector);
        }
    }
}