using Factories.Transforms;

namespace Abilities.Handlers
{
    public interface ISummonAbilityHandler
    {
        void Summon(string hash, TransformHashValuesData data);
    }
}