using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Animations.Configs;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.AnimationsQueue.Factory
{
    public class AnimationsQueueFactory : IAnimationsQueueFactory
    {
        private readonly IIdentifierService _identifiers;

        public AnimationsQueueFactory(IIdentifierService identifiers) => _identifiers = identifiers;

        public GameEntity CreateAnimationQueue(IEnumerable<AnimationSetup> animationSetups, int producerId, int targetId, int parentAbilityId)
        {
            return CreateEntity.Empty("AnimationQueue")
                .AddId(_identifiers.Next())
                .AddAnimationsQueue(new Queue<AnimationSetup>(animationSetups))
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddParentAbilityId(parentAbilityId)
                .With(x => x.isMoveNext = true)
                ;
        }
    }
}
