using Code.Gameplay.Features.Progress.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Progress
{
    public class ProgressFeature : Feature
    {
        public ProgressFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateNormalizeTimeByProgressedEntitiesSystem>());
        }
    }
}
