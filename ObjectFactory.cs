using System.Collections.Generic;
using System.Linq;

namespace CSharpBoosts
{
    public class ObjectFactory
    {
        private Dictionary<string, IObjectFactory> _objectFactories;

        internal ObjectFactory()
        {
        }

        internal IEnumerable<IObjectFactory> Factories
        {
            set => _objectFactories = value.ToDictionary(objectFactory => objectFactory.ObjectHash);
        }

        public IObject Create(ObjectData data)
        {
            return _objectFactories[data.Hash].Create(data.Values);
        }
    }
}