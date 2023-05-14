using System.Collections.Generic;

namespace CSharpBoosts
{
    public interface ILevelDatabase<out T>
    {
        IEnumerable<T> Query(int level);
    }
}