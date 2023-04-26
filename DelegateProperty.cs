using System;

namespace CSharpBoosts
{
    public class DelegateProperty<T, TValue>
    {
        private Func<T, TValue> _get;
        private T _obj;
        private Action<T, TValue> _set;

        public Func<T, TValue> Get
        {
            set => _get = value;
        }

        public T Obj
        {
            set => _obj = value;
        }

        public Action<T, TValue> Set
        {
            set => _set = value;
        }

        public TValue Value
        {
            get => _get(_obj);
            set => _set(_obj, value);
        }
    }
}