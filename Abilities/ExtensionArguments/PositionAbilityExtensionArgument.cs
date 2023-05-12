using System.Numerics;
using Transforms;

namespace Abilities
{
    public class PositionAbilityExtensionArgument : IAbilityExtensionArgument
    {
        public Vector3 GetPosition(IAbilityArguments args)
        {
            return args.Position;
        }

        public ITransform GetTarget(IAbilityArguments args)
        {
            return null;
        }
    }
}