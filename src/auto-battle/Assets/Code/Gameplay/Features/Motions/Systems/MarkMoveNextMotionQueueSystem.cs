using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Factory;
using Code.Gameplay.Features.Movement.Factory;
using Entitas;

namespace Code.Gameplay.Features.Motions.Systems
{
    public class MarkMoveNextMotionQueueSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _motionQueue;
        private readonly IGroup<GameEntity> _motions;
        private readonly List<GameEntity> _buffer = new(16);

        public MarkMoveNextMotionQueueSystem(GameContext game)
        {
            _motionQueue = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Id,
                        GameMatcher.MotionQueue
                    )
                    .NoneOf(GameMatcher.MoveNext));
            
            _motions = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Progress,
                        GameMatcher.ProgressFilled,
                        GameMatcher.MotionLinkedQueueId
                    ));
        }

        public void Execute()
        {
            foreach (var motionQueue in _motionQueue.GetEntities(_buffer))
            foreach (var motion in _motions)
            {
                if(motion.MotionLinkedQueueId != motionQueue.Id)
                    continue;

                motionQueue.isMoveNext = true;
            }
        }
    }
}
