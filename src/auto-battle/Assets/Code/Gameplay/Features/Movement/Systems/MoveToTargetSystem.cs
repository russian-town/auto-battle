using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class MoveToTargetSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movements;
        private readonly IGroup<GameEntity> _producers;
        private readonly IGroup<GameEntity> _targets;

        public MoveToTargetSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _movements = game.GetGroup(GameMatcher
                .AllOf
                (
                    GameMatcher.Movement,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.Progress,
                    GameMatcher.Speed,
                    GameMatcher.MoveToTarget
                ));
            
            _producers = game.GetGroup(GameMatcher
                .AllOf
                (
                    GameMatcher.Id,
                    GameMatcher.WorldPosition
                ));
            
            _targets = game.GetGroup(GameMatcher
                .AllOf
                (
                    GameMatcher.Id,
                    GameMatcher.WorldPosition
                ));
        }

        public void Execute()
        {
            foreach (var movement in _movements)
            foreach (var producer in _producers)
            foreach (var target in _targets)
            {
                if (producer.Id != movement.ProducerId)
                    continue;
                
                if(target.Id != producer.TargetId)
                    continue;

                var distance = Vector3.Distance(producer.WorldPosition, target.WorldPosition);
                movement.ReplaceProgress(ClampProgress(movement, distance));
                
                var position =
                    Vector3.Lerp(producer.WorldPosition, target.WorldPosition, movement.Progress);
                
                producer.ReplaceWorldPosition(position);
            }
        }

        private float ClampProgress(GameEntity movement, float distance) =>
            Mathf.Clamp01(movement.Progress + _time.DeltaTime / distance * movement.Speed); 
    }
}
