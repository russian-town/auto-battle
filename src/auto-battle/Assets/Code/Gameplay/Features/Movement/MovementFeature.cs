using Code.Gameplay.Features.Movement.Systems;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(GameContext game)
        {
            Add(new DirectionalDeltaMoveSystem(game));
            Add(new UpdateTransformPositionSystem(game));
        }
    }
}
