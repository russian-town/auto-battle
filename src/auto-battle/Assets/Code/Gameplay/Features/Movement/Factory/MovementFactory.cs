using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Movement.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Factory
{
    public class MovementFactory : IMovementFactory
    {
        public GameEntity CreateMovement(MovementSetup setup, int producerId, int targetId)
        {
            return CreateEntity.Empty("Movement")
                .With(x => x.isMovement = true)
                .AddTargetPositions(new Queue<Vector3>(setup.TargetPositions))
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddProgress(0f)
                .AddSpeed(setup.Speed)
                .With(x => x.isReached = true)
                ;
        }
    }
}
