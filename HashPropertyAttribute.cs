using System;

namespace CSharpBoosts
{
    public class HashPropertyAttribute : Attribute
    {
        public string Hash { get; }

        public HashPropertyAttribute(string hash)
        {
            Hash = hash;
        }
    }
}