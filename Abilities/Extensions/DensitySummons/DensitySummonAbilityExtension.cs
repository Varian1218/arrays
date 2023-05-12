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
        private DensitySummonAbilityExtensionProperties _extensionProperties;

        public IAbility Ability { get; set; } = new Ability();
        IAbilityExtensionArgument IAbilityExtension.Argument => NoneAbilityExtensionArgument.Instance;
        public THandler Handler { private get; set; }

        public bool Active(IAbilityArguments args)
        {
            if (Ability.Cooldown.Value > 0f) return false;
            Summon();
            return true;
        }

        private async void Summon()
        {
            Ability.Processing = true;
            Ability.Cooldown.Value = Ability.Cooldown.MaxValue;
            if (_extensionProperties.AnimationHash?.Length > 0)
            {
                Handler.TaskAnimator.Animator.Play(_extensionProperties.AnimationHash);
                await Handler.TaskAnimator.WaitMessage(_extensionProperties.AnimationMessage);
            }

            foreach (var position in Handler.SelectPosition(_extensionProperties.SpawnDensity + Handler.Level))
            {
                Handler.Summon(_extensionProperties.SpawnHash, new TransformObjectData
                {
                    Transform = new TransformData
                    {
                        Position = position
                    }
                });
            }

            Ability.Processing = true;
        }
    }
}