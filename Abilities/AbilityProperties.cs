namespace Abilities
{
    public class AbilityProperties : IAbilityProperties
    {
        public Cooldown Cooldown { get; }
        public bool Processing { get; set; }
    }
}