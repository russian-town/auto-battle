using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class DirectionalDeltaMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public DirectionalDeltaMoveSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Transform
                    ));
        }

        public void Execute()
        {
            foreach (var mover in _movers)
                mover.Transform.position = mover.WorldPosition;
        }
    }
}
