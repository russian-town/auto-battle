using Code.Gameplay.Features.Movement.Configs;

namespace Code.Gameplay.Features.Movement.Factory
{
    public interface IMovementFactory
    {
        GameEntity CreateMovement(MovementSetup setup, int producerId, int targetId);
    }
}
