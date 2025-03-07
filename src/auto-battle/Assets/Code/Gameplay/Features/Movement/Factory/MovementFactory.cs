using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Movement.Config;

namespace Code.Gameplay.Features.Movement.Factory
{
    public class MovementFactory : IMovementFactory
    {
        public GameEntity CreateMovement(MovementConfig config, int animatorId, int producerId, int targetId)
        {
            return CreateEntity.Empty("Movement")
                .AddProgress(0)
                .With(x => x.isMovement = true)
                .AddTargetPosition(config.TargetPosition)
                .AddAnimatorId(animatorId)
                .AddProducerId(producerId)
                .AddTargetId(targetId);
        }
    }
}
