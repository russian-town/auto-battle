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

        public GameEntity CreateMotionQueue(IEnumerable<MotionConfig> motions, int animatorId, int producerId, int targetId)
        {
            return CreateEntity.Empty("MotionQueue")
                .AddId(_identifiers.Next())
                .AddMotionQueue(new Queue<MotionConfig>(motions))
                .AddProgress(0f)
                .With(x => x.isProgressFilled = true)
                .AddAnimatorId(animatorId)
                .AddProducerId(producerId)
                .AddTargetId(targetId);
        }
    }
}
