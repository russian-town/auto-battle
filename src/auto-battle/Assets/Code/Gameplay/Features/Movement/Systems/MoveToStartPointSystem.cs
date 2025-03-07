using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class MoveToStartPointSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movements;
        private readonly IGroup<GameEntity> _producers;

        public MoveToStartPointSystem(GameContext game, ITimeService time)
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
                    GameMatcher.MoveToStartPoint
                ));
            
            _producers = game.GetGroup(GameMatcher
                .AllOf
                (
                    GameMatcher.Id,
                    GameMatcher.WorldPosition,
                    GameMatcher.StartPointPosition
                ));
        }

        public void Execute()
        {
            foreach (var movement in _movements)
            foreach (var producer in _producers)
            {
                if (producer.Id != movement.ProducerId)
                    continue;

                var distance = Vector3.Distance(producer.WorldPosition, producer.StartPointPosition);
                movement.ReplaceProgress(ClampProgress(movement, distance));
                
                var position =
                    Vector3.Lerp(producer.WorldPosition, producer.StartPointPosition, movement.Progress);
                
                producer.ReplaceWorldPosition(position);
            }
        }

        private float ClampProgress(GameEntity movement, float distance) =>
            Mathf.Clamp01(movement.Progress + _time.DeltaTime / distance * movement.Speed); 
    }
}
