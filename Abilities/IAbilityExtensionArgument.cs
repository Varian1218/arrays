using System.Numerics;
using Transforms;

namespace Abilities
{
    public interface IAbilityExtensionArgument
    {
        Vector3 GetPosition(IAbilityArguments args);
        ITransform GetTarget(IAbilityArguments args);
    }
}