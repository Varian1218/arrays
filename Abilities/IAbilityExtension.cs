namespace Abilities
{
    public interface IAbilityExtension
    {
        IAbility Ability { get; set; }
        IAbilityExtensionArgument Argument { get; }
        bool Active(IAbilityArguments args);
    }
    
    public interface IAbilityExtension<in THandler> : IAbilityExtension
    {
        THandler Handler { set; }
    }
}