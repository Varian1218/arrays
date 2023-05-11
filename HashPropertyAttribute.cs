using System;

namespace CSharpBoosts
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HashPropertyAttribute : Attribute
    {
        public string Hash { get; }

        public HashPropertyAttribute(string hash)
        {
            Hash = hash;
        }
    }
}