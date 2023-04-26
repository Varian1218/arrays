using System;
using System.Reflection;

namespace CSharpBoosts
{
    public static class DelegatePropertyUtility
    {
        public static DelegateProperty<T, TValue> Create<T, TValue>(T obj, PropertyInfo propertyInfo)
        {
            return new DelegateProperty<T, TValue>
            {
                Get = DelegateUtility.CreateDelegate<Func<T, TValue>>(null, propertyInfo.GetMethod),
                Obj = obj,
                Set = DelegateUtility.CreateDelegate<Action<T, TValue>>(null, propertyInfo.SetMethod)
            };
        }
    }
}