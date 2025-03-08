using Code.Gameplay.Features.Animations.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Animations
{
    public class AnimationsFeature : Feature
    {
        public AnimationsFeature(ISystemFactory systems)
        {
            Add(systems.Create<PlayAnimationsWithAnimatorsSystem>());
            
            Add(systems.Create<CreateAnimationEventsByAnimationsSystem>());
            Add(systems.Create<SetAnimationsProgressSystem>());
            Add(systems.Create<SyncAnimationFramesSystem>());
            Add(systems.Create<CompleteAnimationSystem>());
            
            Add(systems.Create<CleanupCompletedAnimationsSystem>());
            
        }
    }
}
