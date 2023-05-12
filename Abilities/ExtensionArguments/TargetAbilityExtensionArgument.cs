using System.Numerics;
using Transforms;

namespace Abilities
{
    public class TargetAbilityExtensionArgument : IAbilityExtensionArgument
    {
        public Vector3 GetPosition(IAbilityArguments args)
        {
            return Vector3.Zero;
        }

        public ITransform GetTarget(IAbilityArguments args)
        {
            return args.Target;
        }
    }
}