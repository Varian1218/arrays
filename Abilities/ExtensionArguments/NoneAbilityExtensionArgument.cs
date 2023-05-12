using System.Numerics;
using Transforms;

namespace Abilities
{
    public class NoneAbilityExtensionArgument : IAbilityExtensionArgument
    {
        public static readonly NoneAbilityExtensionArgument Instance = new();

        Vector3 IAbilityExtensionArgument.GetPosition(IAbilityArguments args)
        {
            return Vector3.Zero;
        }

        ITransform IAbilityExtensionArgument.GetTarget(IAbilityArguments args)
        {
            return null;
        }
    }
}