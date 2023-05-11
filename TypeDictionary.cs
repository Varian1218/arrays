using System;
using System.Collections.Generic;

namespace CSharpBoosts
{
    public class TypeDictionary
    {
        private readonly Dictionary<Type, Type> _types = new();
        public Type this[Type type] => _types[type];

        public void Add<TKey, TValue>() where TValue : TKey
        {
            _types.Add(typeof(TKey), typeof(TValue));
        }

        public Type Get<T>()
        {
            return _types[typeof(T)];
        }

        public Type GetKeyIfNotExits(Type key)
        {
            return TryGet(key, out var value) ? value : key;
        }

        public Type GetKeyIfNotExits<T>()
        {
            return GetKeyIfNotExits(typeof(T));
        }

        public bool TryGet<T>(out Type type)
        {
            return _types.TryGetValue(typeof(T), out type);
        }

        public bool TryGet(Type key, out Type type)
        {
            return _types.TryGetValue(key, out type);
        }
    }
}