namespace Abilities
{
    public interface IAbility
    {
        Cooldown Cooldown { get; }
        bool Processing { get; set; }
    }
}