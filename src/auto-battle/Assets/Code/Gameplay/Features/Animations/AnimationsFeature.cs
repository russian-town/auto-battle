using Code.Gameplay.Features.Animations.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Animations
{
    public class AnimationsFeature : Feature
    {
        public AnimationsFeature(ISystemFactory systems)
        {
            Add(systems.Create<PlayIdleAnimationSystem>());
            Add(systems.Create<PlayDefaultAttackAnimationSystem>());
            Add(systems.Create<PlayDoubleStrikeAnimationSystem>());
            Add(systems.Create<PlayBlockAnimationSystem>());
            Add(systems.Create<PlayCounterattackAnimationSystem>());
            Add(systems.Create<PlayDodgeAnimationSystem>());
            Add(systems.Create<PlayKnockdownAnimationSystem>());
            Add(systems.Create<PlayHitAnimationSystem>());
            Add(systems.Create<PlayMoveToPositionAnimationSystem>());
            Add(systems.Create<PlayGetupAnimationSystem>());
            Add(systems.Create<MarkCompletedIdleAnimationSystem>());
            
            Add(systems.Create<CreateAnimationEventsByAnimationsSystem>());
            Add(systems.Create<SyncAnimationFramesSystem>());
            Add(systems.Create<MarkMoveNextParentQueueSystem>());
            
            Add(systems.Create<CleanupCompletedAnimationsSystem>());
        }
    }
}
