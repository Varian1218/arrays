using System.Collections.Generic;
using System.Numerics;

namespace Abilities.Handlers
{
    public interface ISelectPositionAbilityHandler
    {
        IEnumerable<Vector3> SelectPosition(float density);
    }
}