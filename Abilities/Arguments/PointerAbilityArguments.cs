using System.Numerics;
using Transforms;

namespace Abilities
{
    public class PointerAbilityArguments : IAbilityArguments
    {
        public Vector3 Position { get; }
        public ITransform Target { get; }
    }
}