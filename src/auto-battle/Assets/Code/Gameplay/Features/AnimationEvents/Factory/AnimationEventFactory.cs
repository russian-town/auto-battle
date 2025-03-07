using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.AnimationEvents.Configs;

namespace Code.Gameplay.Features.AnimationEvents.Factory
{
    public class AnimationEventFactory : IAnimationEventFactory
    {
        public GameEntity CreateAnimationEvent(AnimationEventSetup setup, int animationLinkedId, int producerId, int targetId)
        {
            return CreateEntity.Empty("AnimationEvent")
                .AddAnimationLinkedId(animationLinkedId)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .With(x => x.isAnimationEvent = true)
                .AddTargetFrame(setup.TargetFrame)
                .With(x => x.AddEffectSetups(setup.EffectSetups), when: !setup.EffectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(setup.StatusSetups), when: !setup.StatusSetups.IsNullOrEmpty())
                ;
        }
    }
}
