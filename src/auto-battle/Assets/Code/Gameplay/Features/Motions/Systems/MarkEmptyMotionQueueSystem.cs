using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Motions.Systems
{
    public class MarkEmptyMotionQueueSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _motionQueue;
        private readonly List<GameEntity> _buffer = new(4);

        public MarkEmptyMotionQueueSystem(GameContext game)
        {
            _motionQueue = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.MotionQueue)
                .NoneOf(GameMatcher.Empty));
        }

        public void Execute()
        {
            foreach (var motionQueue in _motionQueue.GetEntities(_buffer))
            {
                if (motionQueue.MotionQueue.Count == 0)
                    motionQueue.isEmpty = true;
            }
        }
    }
}
