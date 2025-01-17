using UnityEngine;

namespace Code.Gameplay.Features.Damage.Factory
{
    public interface IHealthBarFactory
    {
        GameEntity CreateHealthBar(int targetId, Transform parent);
    }
}
