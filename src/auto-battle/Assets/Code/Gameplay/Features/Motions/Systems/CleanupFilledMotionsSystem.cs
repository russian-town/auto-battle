using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Motions.Systems
{
    public class CleanupFilledMotionsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _motions;
        private readonly List<GameEntity> _buffer = new(16);

        public CleanupFilledMotionsSystem(GameContext game)
        {
            _motions = game.GetGroup(GameMatcher.AllOf(GameMatcher.ProgressFilled));
        }

        public void Cleanup()
        {
            foreach (var motion in _motions.GetEntities(_buffer))
            {
                motion.Destroy();
            }
        }
    }
}
