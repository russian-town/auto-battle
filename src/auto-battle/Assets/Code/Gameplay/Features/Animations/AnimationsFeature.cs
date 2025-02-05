using Code.Gameplay.Features.Animations.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Animations
{
    public class AnimationsFeature : Feature
    {
        public AnimationsFeature(ISystemFactory systems)
        {
            Add(systems.Create<PlayMoveToTargetAnimationSystem>());
            Add(systems.Create<PlayMoveToStartPointAnimationSystem>());
            Add(systems.Create<CompleteMoveToTargetAnimationSystem>());
            Add(systems.Create<CompleteMoveToStartPointAnimationSystem>());
            
            Add(systems.Create<PlayDefaultAttackAnimationSystem>());
            Add(systems.Create<PlayCounterattackAnimationSystem>());
            Add(systems.Create<PlayDoubleStrikeAnimationSystem>());
            Add(systems.Create<PlayDodgeAnimationSystem>());
            Add(systems.Create<PlayHitAnimationSystem>());
            Add(systems.Create<PlayBlockAnimationSystem>());
            Add(systems.Create<PlayFallAnimationSystem>());
            
            Add(systems.Create<StartAnimationWithAnimationTimeSystem>());
            Add(systems.Create<PlayAnimationWithAnimationTimeSystem>());
            
            Add(systems.Create<CreateAnimationEventsSystem>());
            Add(systems.Create<InvokeAnimationEventSystem>());
            
            Add(systems.Create<InterruptAnimationOnHitsSystem>());
            
            Add(systems.Create<CleanupInvokedEventsSystem>());
            Add(systems.Create<CleanupEventsWithParentAnimationIdSystem>());
            Add(systems.Create<FinalizeProcessedAnimationsSystem>());
        }
    }
}
