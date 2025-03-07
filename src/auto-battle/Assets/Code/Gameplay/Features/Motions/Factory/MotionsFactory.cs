using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Motions.Configs;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Motions.Factory
{
    public class MotionsFactory : IMotionsFactory
    {
        private readonly IIdentifierService _identifiers;

        public MotionsFactory(IIdentifierService identifiers) => _identifiers = identifiers;

        public GameEntity CreateMotion(MotionConfig config, int animatorId, int producerId, int targetId)
        {
            return CreateEntity.Empty("Motion")
                .AddId(_identifiers.Next())
                .With(x => x.isMotion = true)
                .AddAnimatorId(animatorId)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddProgress(0f)
                .AddAnimationSetup(config.AnimationSetup)
                .With(x => x.AddMovementConfig(config.MovementConfig), when: config.MovementConfig != null);
        }
    }
}
