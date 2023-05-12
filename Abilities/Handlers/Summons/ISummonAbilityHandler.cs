using Transforms.Objects;

namespace Abilities.Handlers
{
    public interface ISummonAbilityHandler
    {
        void Summon(string hash, TransformObjectData data);
    }
}