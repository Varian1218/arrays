using System;

namespace CSharpBoosts
{
    public class HashAttribute : Attribute
    {
        public HashAttribute(string hash) => Hash = hash;
        public string Hash { get; }
    }
}