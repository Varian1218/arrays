using System;

namespace CSharpExtensions
{
    public static class RandomUtils
    {
        public static T[] Next<T>(int count, Func<T> next)
        {
            var ts = new T[count];
            for (var i = 0; i < count; i++)
            {
                ts[i] = next();
            }

            return ts;
        }
    }
}