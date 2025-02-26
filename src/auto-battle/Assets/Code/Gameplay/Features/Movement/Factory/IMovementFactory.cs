using Code.Gameplay.Features.Movement.Config;

namespace Code.Gameplay.Features.Movement.Factory
{
    public interface IMovementFactory
    {
        void CreateMovement(MovementSetup movementSetup, int producerId, int targetId);
    }
}
