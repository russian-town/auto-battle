using Code.Gameplay.Features.AnimationEvents.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.AnimationEvents
{
    public class AnimationEventsFeature : Feature
    {
        public AnimationEventsFeature(ISystemFactory systems)
        {
            Add(systems.Create<InvokeAnimationEventsSystem>());
            
            Add(systems.Create<CreateEffectsByInvokedAnimationEventsSystem>());
            Add(systems.Create<CreateStatusesByInvokedAnimationEventsSystem>());
            
            Add(systems.Create<CleanupProcessedAnimationEventsSystem>());
        }
    }
}
