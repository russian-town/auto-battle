using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Animations.Configs;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Factory
{
    public class AnimationEventEventFactory : IAnimationEventFactory
    {
        private readonly IIdentifierService _identifiers;

        public AnimationEventEventFactory(IIdentifierService identifiers) => _identifiers = identifiers;

        public GameEntity CreateAnimation(EventSetup eventSetup, int producerId, int targetId, AnimationClip clip = null)
        {
            return CreateEntity.Empty("AnimationEvent")
                .AddId(_identifiers.Next())
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .With(x => x.AddAnimationHash(clip.GetHashCode()), when: clip != null)
                .With(x => x.AddAnimationClip(clip), when: clip != null)
                .With(x => x.AddAnimationPercent(eventSetup.AnimationPercent), when: clip != null)
                .With(x => x.AddAnimationPercentLeft(0f), when: clip != null)
                .With(x => x.AddEffectSetups(eventSetup.EffectSetups), when: !eventSetup.EffectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(eventSetup.StatusSetups), when: !eventSetup.StatusSetups.IsNullOrEmpty());
        }
    }
}
