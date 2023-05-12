using System.Numerics;
using Transforms;

namespace Abilities
{
    public class AbilityArguments : IAbilityArguments
    {
        public Vector3 Position { get; set; }
        public ITransform Target { get; set; }
    }
}