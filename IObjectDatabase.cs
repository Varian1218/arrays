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
        IEnumerable<T> Query<T>() where T : TObject;
        IEnumerable<T> Query<T>(Type type) where T : TObject;
        IEnumerable<T> Query<T>(string hash) where T : TObject;
        IEnumerable<(string, IEnumerable<T>)> Where<T>();
    }
}