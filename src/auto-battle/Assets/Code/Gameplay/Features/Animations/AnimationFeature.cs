using Code.Gameplay.Features.Animations.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Animations
{
    public class AnimationFeature : Feature
    {
        public AnimationFeature(ISystemFactory systems)
        {
            Add(systems.Create<PlayAnimationsByEntitiesWithHashCodeSystem>());
            Add(systems.Create<SetCurrentAnimationFrameSystem>());
            
            Add(systems.Create<CreateEffectsByAnimatedEntitiesSystem>());
            Add(systems.Create<CreateStatusesByAnimatedEntitiesSystem>());
            
            Add(systems.Create<CompleteAnimationByAnimatedEntitiesSystem>());
        }
    }
}
