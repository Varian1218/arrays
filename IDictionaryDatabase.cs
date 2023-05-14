using System.Collections;

namespace CSharpBoosts
{
    public interface IDictionaryDatabase
    {
        IDictionary Query(string hash);
    }
}