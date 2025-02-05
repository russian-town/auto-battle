using Code.Gameplay.Features.Animations.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Animations
{
    public class AnimationsFeature : Feature
    {
        public AnimationsFeature(ISystemFactory systems)
        {
            Add(systems.Create<PlayAnimationSystem>());
            
            Add(systems.Create<StartAnimationWithAnimationTimeSystem>());
            Add(systems.Create<AnimationTimerSystem>());
            
            Add(systems.Create<CreateAnimationEventsSystem>());
            Add(systems.Create<InvokeAnimationEventSystem>());
            
            Add(systems.Create<InterruptAnimationOnHitsSystem>());
            
            Add(systems.Create<CleanupInvokedEventsSystem>());
            Add(systems.Create<CleanupEventsWithParentAnimationIdSystem>());
            Add(systems.Create<FinalizeProcessedAnimationsSystem>());
        }
    }
}
