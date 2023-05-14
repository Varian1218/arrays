namespace Abilities
{
    public class Ability : IAbility
    {
        public Cooldown Cooldown { get; }
        public bool Processing { get; set; }

        public bool Active(IAbilityExtensionArgument arg, bool cooldown)
        {
            if (Processing || Cooldown.Value > 0) return false;
            Processing = true;
            if (cooldown)
            {
                Cooldown.Value = Cooldown.MaxValue;   
            }

            return true;
        }

        public void DeActive(bool cooldown)
        {
            if (cooldown)
            {
                Cooldown.Value = Cooldown.MaxValue;   
            }
            Processing = false;
        }
    }
}