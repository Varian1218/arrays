using System.Collections;
using System.Collections.Generic;

namespace CSharpBoosts
{
    public class DictionaryDatabase : IDictionaryDatabase
    {
        public IDictionary<string, IDictionary> Objects { get; set; }
        
        public IDictionary Query(string hash)
        {
            return Objects[hash];
        }
    }
}