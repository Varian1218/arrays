using System;
using System.Collections.Generic;

namespace CSharpBoosts
{
    public static class RandomUtility
    {
        public static IEnumerable<int> NextInts(this Random random, int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return random.Next();
            }
        }
        
        public static IEnumerable<int> NextInts(this Random random, int count, int max)
        {
            for (var i = 0; i < count; i++)
            {
                yield return random.Next(max);
            }
        }
    }
}