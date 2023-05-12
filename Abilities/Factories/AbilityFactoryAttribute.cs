using System;
using CSharpBoosts;

namespace Abilities.Factories
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AbilityFactoryAttribute : Attribute, IHashObject
    {
        public AbilityFactoryAttribute(string hash)
        {
            Hash = hash;
        }

        public string Hash { get; }
    }
}