using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class IncreaseProgressByMovements : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movements;
        private readonly List<GameEntity> _buffer = new(8);

        public IncreaseProgressByMovements(GameContext game, ITimeService time)
        {
            _game = game;
            _time = time;

            _movements = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Movement,
                        GameMatcher.Progress,
                        GameMatcher.TargetPosition,
                        GameMatcher.Speed
                    )
                    .NoneOf(GameMatcher.Reached));
        }

        public void Execute()
        {
            foreach (var movement in _movements.GetEntities(_buffer))
            {
                movement.ReplaceProgress(movement.Progress + _time.DeltaTime * movement.Speed);

                if (movement.Progress >= 1f)
                {
                    var animator = _game.GetEntityWithId(movement.ProducerId);
                    animator.FighterAnimator.Play(Animator.StringToHash("Idle"), 0f, 0f);
                    movement.isReached = true;
                }
            }
        }
    }
}
