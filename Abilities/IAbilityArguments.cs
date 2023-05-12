using System.Numerics;
using Transforms;

namespace Abilities
{
    public interface IAbilityArguments
    {
        Vector3 Position { get; }
        ITransform Target { get; }
    }
}