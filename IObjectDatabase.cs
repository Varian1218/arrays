using System;
using System.Collections.Generic;

namespace CSharpBoosts
{
    public interface IObjectDatabase
    {
        IEnumerable<object> Query(string hash);
        IEnumerable<object> Query(Type type);
        IEnumerable<T> Query<T>();
        IEnumerable<T> Query<T>(string hash);
    }
}