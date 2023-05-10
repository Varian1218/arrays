using System.Collections.Generic;
using System.Linq;
using Type = System.Type;

namespace CSharpBoosts
{
    public class ObjectDatabase : IObjectDatabase
    {
        private Dictionary<string, IEnumerable<object>> _objects;

        public IEnumerable<(IEnumerable<object> Objects, Type Type)> TypeObjects
        {
            set => Objects = value.Select(it => (GetHash(it.Type), it.Objects));
        }

        public IEnumerable<(string Hash, IEnumerable<object> Objects)> Objects
        {
            set => _objects = value.ToDictionary(it => it.Hash, it => it.Objects);
        }

        public IEnumerable<IEnumerable<(string, IEnumerable<object>)>> ObjectsMany
        {
            set => Objects = value.SelectMany(it => it);
        }

        private static string GetHash(Type type)
        {
            return type.FullName;
        }

        public IEnumerable<object> Query(string hash)
        {
            return _objects[hash];
        }

        public IEnumerable<object> Query(Type type)
        {
            return Query(GetHash(type));
        }

        public IEnumerable<T> Query<T>()
        {
            return Query(typeof(T)).Select(it => (T)it);
        }

        public IEnumerable<T> Query<T>(string hash)
        {
            return Query(hash).Select(it => (T)it);
        }
    }
}