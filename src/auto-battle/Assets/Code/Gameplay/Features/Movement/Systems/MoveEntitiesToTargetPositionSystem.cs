using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class MoveEntitiesToTargetPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;
        private readonly IGroup<GameEntity> _movements;

        public MoveEntitiesToTargetPositionSystem(GameContext game)
        {
            _movements = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ProducerId,
                    GameMatcher.TargetPosition
                    ));
            
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition
                    ));
        }

        public void Execute()
        {
            foreach (var movement in _movements)
            foreach (var mover in _movers)
            {
                if(movement.ProducerId != mover.Id)
                    continue;
                
                var position =
                    Vector3.Lerp(mover.WorldPosition, movement.TargetPosition, Mathf.Clamp01(movement.Progress));
                mover.ReplaceWorldPosition(position);
            }
        }
    }
}
