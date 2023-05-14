using Abilities.Factories;
using Abilities.Handlers;
using Animators.TaskAnimators;
using CSharpBoosts;
using Factories;

namespace Abilities.Extensions
{
    [AbilityFactory(DensitySummonAbility.Hash)]
    public class DensitySummonAbilityFactory<THandler> : IFactory<ObjectData, IAbilityExtension<THandler>>
        where THandler : ILevelAbilityHandler, ISelectPositionAbilityHandler, ISummonAbilityHandler, ITaskAnimatorObject
    {
        public IAbilityExtension<THandler> Create(ObjectData material)
        {
            return new DensitySummonAbilityExtension<THandler>
            {
                Data = material.Values.To<DensitySummonAbilityExtensionData>(StringUtils.ToPascalCase)
            };
        }
    }
}