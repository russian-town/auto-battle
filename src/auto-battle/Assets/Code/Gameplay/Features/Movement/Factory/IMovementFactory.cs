using Code.Gameplay.Features.Movement.Config;

namespace Code.Gameplay.Features.Movement.Factory
{
    public interface IMovementFactory
    {
        GameEntity CreateMovement(MovementSetup setup, int animatorId, int producerId, int targetId);
    }
}
