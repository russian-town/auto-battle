using Code.Gameplay.Features.HealthBar.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.HealthBar
{
    public class HealthBarFeature : Feature
    {
        public HealthBarFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateHealthByTargetEntitiesSystem>());
        }
    }
}
