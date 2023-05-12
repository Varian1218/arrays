namespace Abilities
{
    public interface ICooldown
    {
        float MaxValue { get; set; }
        float Value { get; set; }
    }
}