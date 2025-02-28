using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class UpdateRotationByEntitiesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public UpdateRotationByEntitiesSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Transform,
                    GameMatcher.WorldRotation
                ));
        }

        public void Execute()
        {
            foreach (var mover in _movers)
                mover.Transform.rotation = mover.WorldRotation;
        }
    }
}
