using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.AnimationEvents.Configs;

namespace Code.Gameplay.Features.AnimationEvents.Factory
{
    public class AnimationEventFactory : IAnimationEventFactory
    {
        public GameEntity CreateAnimationEvent(AnimationEventConfig config, int producerId, int targetId)
        {
            return CreateEntity.Empty("AnimationEvent")
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .With(x => x.isAnimationEvent = true)
                .AddTargetFrame(config.TargetFrame)
                .With(x => x.AddEffectSetups(config.EffectSetups), when: !config.EffectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(config.StatusSetups), when: !config.StatusSetups.IsNullOrEmpty())
                ;
        }
    }
}
