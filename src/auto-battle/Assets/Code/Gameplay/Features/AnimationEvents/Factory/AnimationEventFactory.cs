using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.AnimationEvents.Configs;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.AnimationEvents.Factory
{
    public class AnimationEventFactory : IAnimationEventFactory
    {
        private readonly IIdentifierService _identifiers;

        public AnimationEventFactory(IIdentifierService identifiers) => _identifiers = identifiers;

        public GameEntity CreateAnimationEvent(AnimationEventSetup setup, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddTimeLeft(setup.Delay)
                .With(x => x.AddHashCode(setup.HashCode), when: setup.TargetAnimation)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .With(x => x.isAnimationEvent = true)
                .With(x => x.AddEffectSetups(setup.EffectSetups), when: !setup.EffectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(setup.StatusSetups), when: !setup.StatusSetups.IsNullOrEmpty())
                ;
        }
    }
}
