using Code.Gameplay.Features.AnimationEvents.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.AnimationEvents
{
    public class AnimationEventsFeature : Feature
    {
        public AnimationEventsFeature(ISystemFactory systems)
        {
            Add(systems.Create<InvokeAnimationEventsWithHashCodeSystem>());
            Add(systems.Create<InvokeAnimationEventsWithoutHashCodeSystem>());
            
            Add(systems.Create<CreateEffectsByInvokedEventsSystem>());
            Add(systems.Create<CreateStatusesByInvokedEventsSystem>());
            
            Add(systems.Create<CleanupProcessedAnimationEventsSystem>());
        }
    }
}
