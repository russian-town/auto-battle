using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Movement.Config;

namespace Code.Gameplay.Features.Movement.Factory
{
    public class MovementFactory : IMovementFactory
    {
        public GameEntity CreateMovement(MovementConfig config, int animatorId, int producerId, int targetId)
        {
            var movement = CreateEntity.Empty("Movement")
                .With(x => x.isMovement = true)
                .AddAnimatorId(animatorId)
                .AddProducerId(producerId)
                .AddSpeed(config.Speed)
                .AddTargetId(targetId);
                

            switch (config.MovementTypeId)
            {
                case MovementTypeId.MoveToTarget:
                    return CreateMoveToTarget(movement);
                case MovementTypeId.MoveToStartPoint:
                  return CreateMoveToStartPoint(movement);
            }

            return movement;
        }

        private GameEntity CreateMoveToTarget(GameEntity movement) =>
            movement.With(x => x.isMoveToTarget = true);

        private GameEntity CreateMoveToStartPoint(GameEntity movement) =>
            movement.With(x => x.isMoveToStartPoint = true);
    }
}
