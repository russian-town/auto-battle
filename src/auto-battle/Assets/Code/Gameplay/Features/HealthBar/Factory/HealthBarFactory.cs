using Code.Common.Entity;
using UnityEngine;

namespace Code.Gameplay.Features.HealthBar.Factory
{
    public class HealthBarFactory : IHealthBarFactory
    {
        public void CreateHealthBar(int targetId, Vector3 at, Transform container)
        {
            CreateEntity.Empty("HealthBar")
                .AddTargetId(targetId)
                .AddWorldPosition(at)
                .AddViewPath("Gameplay/HealthBar/HealthBar")
                .AddContainer(container)
                ;
        }
    }
}
