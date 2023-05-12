using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Type = System.Type;

namespace CSharpBoosts
{
    public class ObjectDatabase<TObject> : IObjectDatabase<TObject>
    {
        private Dictionary<string, IEnumerable<TObject>> _objects;

        public IEnumerable<(string Hash, IEnumerable<TObject> Objects)> Objects
        {
            set => _objects = value.ToDictionary(it => it.Hash, it => it.Objects);
        }

        public IEnumerable<TObject> this[string key]
        {
            set => _objects[key] = value;
        }

        public IEnumerator<KeyValuePair<string, IEnumerable<TObject>>> GetEnumerator()
        {
            return _objects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<TObject> Query(string hash)
        {
            return _objects[hash];
        }

        public IEnumerable<TObject> Query(Type type)
        {
            return Query(ObjectDatabaseUtility.GetHash(type));
        }

        public IEnumerable<T> Query<T>() where T : TObject
        {
            return Query(typeof(T)).Select(it => (T)it);
        }

        public IEnumerable<T> Query<T>(Type type) where T : TObject
        {
            return Query<T>(ObjectDatabaseUtility.GetHash(type));
        }

        public IEnumerable<T> Query<T>(string hash) where T : TObject
        {
            return Query(hash).Select(it => (T)it);
        }

        public IEnumerable<(string, IEnumerable<T>)> Where<T>()
        {
            return _objects.Where(it => typeof(T).IsAssignableFrom(Type.GetType(it.Key)))
                .Select(it => (it.Key, (IEnumerable<T>)it.Value));
        }
    }
}