namespace Abilities
{
    public interface IAbility
    {
        Cooldown Cooldown { get; }
        bool Processing { get; }

        bool Active(IAbilityExtensionArgument arg, bool cooldown);
        void DeActive(bool cooldown);
    }
}