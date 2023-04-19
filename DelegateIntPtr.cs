using System;

namespace CSharpExtensions
{
    public class DelegateIntPtr : IIntPtr
    {
        private Func<int> _get;
        private Action<int> _set;

        public Func<int> Get
        {
            set => _get = value;
        }

        public Action<int> Set
        {
            set => _set = value;
        }

        public int Value
        {
            get => _get();
            set => _set(value);
        }
    }
}