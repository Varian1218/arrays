using Abilities.Factories;
using Abilities.Handlers;
using Animators.TaskAnimators;
using UnityEngine.UI;

namespace Abilities.Extensions
{
    [AbilityFactory(DensitySummonAbility.Hash)]
    public class DensitySummonAbilityFactory<THandler>
        where THandler : ILevelAbilityHandler, ISelectPositionAbilityHandler, ISummonAbilityHandler, ITaskAnimatorObject
    {
        public IAbilityExtension Create(CanvasScaler.Unit parameter)
        {
            return new DensitySummonAbilityExtension<THandler>();
        }
    }
}