using System;
using System.Collections.Generic;

namespace CSharpBoosts
{
    public interface IObjectDatabase : IObjectDatabase<object>
    {
    }

    public interface IObjectDatabase<TObject> : IEnumerable<KeyValuePair<string, IEnumerable<TObject>>>
    {
        IEnumerable<TObject> Query(string hash);
        IEnumerable<TObject> Query(Type type);
        IEnumerable<T> Query<T>();
        IEnumerable<T> Query<T>(string hash);
        IEnumerable<(string, IEnumerable<T>)> Where<T>();
    }
}