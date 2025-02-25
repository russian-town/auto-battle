using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class DirectionDeltaMoveSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movers;
        private readonly List<GameEntity> _buffer = new(2);

        public DirectionDeltaMoveSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Speed,
                    GameMatcher.TargetPosition,
                    GameMatcher.WorldPosition,
                    GameMatcher.Moving
                ));
        }

        public void Execute()
        {
            foreach (var mover in _movers.GetEntities(_buffer))
            {
                /*
                if (mover.TimeLeft >= 1)
                {
                    mover.isMoving = false;
                    mover.ReplaceTimeLeft(0f);
                }
                */

                var position =
                    Vector3.Lerp(
                        mover.WorldPosition,
                        mover.TargetPosition,
                        mover.TimeLeft);

                mover.ReplaceWorldPosition(position);
            }
        }
    }
}
