using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class IncreaseProgressByMovements : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movements;
        private readonly List<GameEntity> _buffer = new(8);

        public IncreaseProgressByMovements(GameContext game, ITimeService time)
        {
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
                    movement.isReached = true;
            }
        }
    }
}
