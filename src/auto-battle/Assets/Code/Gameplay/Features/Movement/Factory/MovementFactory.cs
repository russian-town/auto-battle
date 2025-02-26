using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Movement.Config;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Movement.Factory
{
    public class MovementFactory : IMovementFactory
    {
        private readonly IIdentifierService _identifiers;

        public MovementFactory(IIdentifierService identifiers) => _identifiers = identifiers;

        public void CreateMovement(MovementSetup movementSetup, int producerId, int targetId)
        {
            CreateEntity.Empty("Movement")
                .AddId(_identifiers.Next())
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddTimeLeft(0f)
                .AddHorizontalGraph(movementSetup.HorizontalGraph)
                .AddVerticalGraph(movementSetup.VerticalGraph)
                .AddSpeedGraph(movementSetup.SpeedGraph)
                .AddAnimationClip(null)
                .With(x => x.AddMoveForwardClip(movementSetup.MoveForwardClip), when: movementSetup.MoveForwardClip != null)
                .With(x => x.AddMoveBackwardClip(movementSetup.MoveBackwardClip), when: movementSetup.MoveBackwardClip != null)
                .With(x => x.isMovement = true)
                ;
        }
    }
}
