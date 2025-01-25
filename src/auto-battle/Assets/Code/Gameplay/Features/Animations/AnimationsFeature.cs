using Code.Gameplay.Features.Animations.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Animations
{
    public class AnimationsFeature : Feature
    {
        public AnimationsFeature(ISystemFactory systems)
        {
            Add(systems.Create<PlayDefaultAttackAnimationSystem>());
            Add(systems.Create<PlayDoubleStrikeAnimationSystem>());
            
            Add(systems.Create<PlayAnimationWithDurationSystem>());
            
            Add(systems.Create<CreateAnimationEventsSystem>());
            Add(systems.Create<InvokeAnimationEventSystem>());
            
            Add(systems.Create<CleanupInvokedEventsSystem>());
            
            Add(systems.Create<FinalizeProcessedAnimationsSystem>());
        }
    }
}
