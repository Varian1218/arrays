using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpBoosts
{
    public class TypeObjectDatabase<TObject> : IObjectDatabase<TObject>
    {
        public IObjectDatabase<TObject> Impl { private get; set; }
        public TypeDictionary Types { private get; set; }

        public IEnumerator<KeyValuePair<string, IEnumerable<TObject>>> GetEnumerator()
        {
            return Impl.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Impl.GetEnumerator();
        }

        public IEnumerable<TObject> Query(string hash)
        {
            return Impl.Query(hash);
        }

        public IEnumerable<TObject> Query(Type type)
        {
            return Impl.Query(Types.GetKeyIfNotExits(type));
        }

        public IEnumerable<T> Query<T>() where T : TObject
        {
            return Query<T>(Types.GetKeyIfNotExits(typeof(T)));
        }

        public IEnumerable<T> Query<T>(Type type) where T : TObject
        {
            return Query(Types.GetKeyIfNotExits(type)).Select(it => (T)it);
        }

        public IEnumerable<T> Query<T>(string hash) where T : TObject
        {
            return Impl.Query<T>(hash);
        }

        public IEnumerable<(string, IEnumerable<T>)> Where<T>()
        {
            return Impl.Where<T>();
        }
    }
}