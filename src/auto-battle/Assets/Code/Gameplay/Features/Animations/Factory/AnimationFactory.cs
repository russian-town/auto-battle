using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Animations.Configs;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Animations.Factory
{
    public class AnimationFactory : IAnimationFactory
    {
        private readonly IIdentifierService _identifiers;

        public AnimationFactory(IIdentifierService identifiers) => _identifiers = identifiers;

        public GameEntity CreateAnimation(AnimationSetup setup, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddAnimationTypeId(setup.TypeId)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddAnimationCurrentTime(0f)
                .With(x => x.isAnimation = true)
                .With(x => x.AddEventSetups(setup.EventSetups), when: !setup.EventSetups.IsNullOrEmpty())
                .With(x => x.AddTargetDistance(setup.TargetDistance), when: setup.TargetDistance > 0f)
                ;
        }
    }
}
