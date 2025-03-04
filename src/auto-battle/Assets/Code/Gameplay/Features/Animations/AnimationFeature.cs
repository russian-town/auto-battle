using Code.Gameplay.Features.Animations.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Animations
{
    public class AnimationFeature : Feature
    {
        public AnimationFeature(ISystemFactory systems)
        {
            Add(systems.Create<PlayAnimationsByFighterAnimatorSystem>());
            Add(systems.Create<UpdateAnimationsFramesSystem>());
            
            Add(systems.Create<CreateAnimationEventsSystem>());
            
            Add(systems.Create<CreateEffectsByInvokeEvents>());
            Add(systems.Create<CreateStatusesByInvokeEvents>());
            
            Add(systems.Create<InvokeAnimationEventsSystem>());
            Add(systems.Create<CreateNextAnimationByAbilitiesSystem>());
            
            Add(systems.Create<CleanupProcessedAnimationEventsSystem>());
            
            Add(systems.Create<CleanupInterruptedAnimationsLinkedAnimationEventsSystem>());
            Add(systems.Create<CleanupInterruptedAnimationsSystem>());
            
            Add(systems.Create<CleanupCompletedAnimationsSystem>());
        }
    }
}
