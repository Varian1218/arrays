namespace Abilities
{
    public interface IAbilityProperties
    {
        Cooldown Cooldown { get; }
        bool Processing { get; set; }
    }
}