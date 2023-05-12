namespace Abilities
{
    public class Ability : IAbility
    {
        public Cooldown Cooldown { get; }
        public bool Processing { get; set; }
    }
}