using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class UpdateEntitiesPositionByMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movements;
        private readonly IGroup<GameEntity> _movers;

        public UpdateEntitiesPositionByMovementSystem(GameContext game)
        {
            _movements = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Movement,
                GameMatcher.AnimatorId,
                GameMatcher.Progress,
                GameMatcher.TargetPosition
                ));
            
            _movers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Id,
                GameMatcher.WorldPosition
                ));
        }

        public void Execute()
        {
            foreach (var movement in _movements)
            foreach (var mover in _movers)
            {
                if(movement.AnimatorId != mover.Id)
                    continue;

                var position =
                    Vector3.Lerp(mover.WorldPosition, movement.TargetPosition, movement.Progress);
                
                mover.ReplaceWorldPosition(position);
            }
        }
    }
}
