using Factories;

namespace Abilities.Factories
{
    public struct AbilityMaterial<THandler>
    {
        public THandler Handler;
        public HashValuesData Values;
    }
}