using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Fight.Systems
{
    public class CleanupTurnSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _turns;
        private readonly List<GameEntity> _buffer = new(1);
        private readonly IGroup<GameEntity> _fighters;

        public CleanupTurnSystem(GameContext game)
        {
            _turns = game.GetGroup(GameMatcher.Turn);
            _fighters = game.GetGroup(GameMatcher.Fighter);
        }

        public void Cleanup()
        {
            foreach (var fighter in _fighters)
            {
                if (fighter.CurrentHealth > 0f)
                    continue;

                foreach (var turn in _turns.GetEntities(_buffer))
                    turn.isDestructed = true;
            }
        }
    }
}
