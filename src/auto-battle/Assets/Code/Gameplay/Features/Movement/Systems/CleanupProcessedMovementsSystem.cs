using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class CleanupProcessedMovementsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _movements;
        private readonly List<GameEntity> _buffer = new(8);

        public CleanupProcessedMovementsSystem(GameContext game)
        {
            _movements = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Movement,
                    GameMatcher.Processed
                    ));
        }

        public void Cleanup()
        {
            foreach (var movement in _movements.GetEntities(_buffer))
            {
                movement.Destroy();
            }
        }
    }
}
