using UnityEngine;

namespace Code.Gameplay.Features.HealthBar.Factory
{
    public interface IHealthBarFactory
    {
        void CreateHealthBar(int targetId, Vector3 at, Transform container);
    }
}
