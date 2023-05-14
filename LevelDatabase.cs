using System.Collections.Generic;
using System.Linq;

namespace CSharpBoosts
{
    public class LevelDatabase<T> : ILevelDatabase<T>
    {
        public IEnumerable<T> Values { private get; set; }

        public IEnumerable<T> Query(int level)
        {
            return Values.Take(level);
        }
    }
}