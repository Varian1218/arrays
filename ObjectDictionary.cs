using System;
using System.Collections.Generic;

namespace CSharpBoosts
{
    public class ObjectDictionary<TObject>
    {
        private IDictionary<string, TObject> _objects;

        public IDictionary<string, TObject> Objects
        {
            set => _objects = value;
        }

        public void Add(Type type, TObject obj)
        {
            if (!type.IsInstanceOfType(obj)) throw new ArgumentException(type.FullName, obj.GetType().FullName);
            _objects.Add(GetHash(type), obj);
        }

        public void AddMany(IEnumerable<(Type type, TObject obj)> objects)
        {
            foreach (var (type, obj) in objects)
            {
                Add(type, obj);
            }
        }

        public void Add<T>(T obj) where T : TObject
        {
            Add(typeof(T), obj);
        }

        public TObject Get(Type type)
        {
            return _objects[GetHash(type)];
        }

        public T Get<T>() where T : TObject
        {
            return (T)Get(typeof(T));
        }

        private static string GetHash(Type type)
        {
            return type.FullName;
        }
    }
}