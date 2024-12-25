using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class UpdateTransformPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public UpdateTransformPositionSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Speed,
                    GameMatcher.Direction,
                    GameMatcher.WorldPosition,
                    GameMatcher.Moving
                ));
        }

        public void Execute()
        {
            foreach (var mover in _movers)
                mover.ReplaceWorldPosition(mover.WorldPosition + mover.Direction * mover.Speed * Time.deltaTime);
        }
    }
}
