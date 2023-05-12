using System.Collections;
using System.Collections.Generic;

namespace CSharpBoosts
{
    public interface IDictionaryDatabase
    {
        IDictionary<string, IDictionary> Objects { get; set; }
    }
}