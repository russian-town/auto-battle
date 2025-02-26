using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class UpdateTimeLeftByMovementsSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movements;
        private readonly IGroup<GameEntity> _producers;
        private readonly List<GameEntity> _buffer = new(8);

        public UpdateTimeLeftByMovementsSystem(GameContext game, ITimeService time)
        {
            _time = time;

            _movements = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Movement,
                        GameMatcher.ProducerId,
                        GameMatcher.HorizontalGraph,
                        GameMatcher.SpeedGraph,
                        GameMatcher.TimeLeft
                    )
                    .NoneOf(GameMatcher.Reached));

            _producers = game.GetGroup(GameMatcher.Id);
        }

        public void Execute()
        {
            foreach (var movement in _movements.GetEntities(_buffer))
            foreach (var producer in _producers)
            {
                if (movement.ProducerId != producer.Id)
                    continue;
                
                if (movement.TimeLeft >= 1f)
                    movement.isReached = true;

                movement.ReplaceTimeLeft(ClampSpeed(movement));
            }
        }

        private float ClampSpeed(GameEntity movement)
        {
            return Mathf.Clamp01(
                movement.TimeLeft
                + _time.DeltaTime
                * movement.SpeedGraph.Evaluate(movement.TimeLeft));
        }
    }
}
