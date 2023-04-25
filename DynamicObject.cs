using System.Collections.Generic;

namespace CSharpBoosts
{
    public class DynamicObject : IDynamicObject
    {
        private IDictionary<string, object> _values;

        public IDictionary<string, object> Values
        {
            set => _values = value;
        }

        public T GetValue<T>(string fieldName)
        {
            return (T)_values[fieldName];
        }
    }
}