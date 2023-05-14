using Abilities.Handlers;
using Animators.TaskAnimators;
using Transforms;
using Transforms.Objects;

namespace Abilities.Extensions
{
    public class DensitySummonAbility
    {
        public const string Hash = "DensitySummonAbility";
    }

    public class DensitySummonAbilityExtension<THandler> : IAbilityExtension<THandler>
        where THandler : ILevelAbilityHandler, ISelectPositionAbilityHandler, ISummonAbilityHandler, ITaskAnimatorObject
    {
        public IAbility Ability { get; set; } = new Ability();
        public IAbilityExtensionArgument Argument => NoneAbilityExtensionArgument.Instance;
        public DensitySummonAbilityExtensionData Data { private get; set; }
        public THandler Handler { private get; set; }

        public bool Active(IAbilityArguments args)
        {
            if (!Ability.Active(Argument, true)) return false;
            Summon();
            return true;
        }

        private async void Summon()
        {
            await Handler.TaskAnimator.WaitMessagePlay(Data.AnimationHash, Data.AnimationMessage);
            foreach (var position in Handler.SelectPosition(Data.SpawnDensity + Handler.Level))
            {
                Handler.Summon(Data.SpawnHash, new TransformObjectData
                {
                    Transform = new TransformData
                    {
                        Position = position
                    }
                });
            }
        }
    }
}