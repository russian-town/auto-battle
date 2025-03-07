using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class SetEntitiesPositionTransformSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public SetEntitiesPositionTransformSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.Transform,
                GameMatcher.WorldPosition
                ));
        }

        public void Execute()
        {
            foreach (var mover in _movers)
                mover.Transform.position = mover.WorldPosition;
        }
    }
}
