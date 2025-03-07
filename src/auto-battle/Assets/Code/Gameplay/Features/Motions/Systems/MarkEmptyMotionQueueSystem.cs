using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Motions.Systems
{
    public class MarkEmptyMotionQueueSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _motions;
        private readonly List<GameEntity> _buffer = new(4);

        public MarkEmptyMotionQueueSystem(GameContext game)
        {
            _motions = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.MotionQueue,
                    GameMatcher.ProgressFilled
                    )
                .NoneOf(GameMatcher.Empty));
        }

        public void Execute()
        {
            foreach (var motion in _motions.GetEntities(_buffer))
            {
                if (motion.MotionQueue.Count == 0)
                    motion.isEmpty = true;
            }
        }
    }
}
