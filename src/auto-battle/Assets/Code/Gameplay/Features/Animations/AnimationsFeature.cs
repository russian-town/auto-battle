using Code.Gameplay.Features.Animations.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Animations
{
    public class AnimationsFeature : Feature
    {
        public AnimationsFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdatePercentByAnimationEventsSystem>());
            
            Add(systems.Create<CreateEffectsByAnimationEventsSystem>());
            Add(systems.Create<CreateStatusesByAnimationEventsSystem>());
            
            Add(systems.Create<CleanupProcessedAnimationEventsSystem>());
        }
    }
}
