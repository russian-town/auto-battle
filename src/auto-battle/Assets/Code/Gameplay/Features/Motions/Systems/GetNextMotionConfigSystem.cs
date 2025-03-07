using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Factory;
using Code.Gameplay.Features.Motions.Factory;
using Code.Gameplay.Features.Movement.Factory;
using Entitas;

namespace Code.Gameplay.Features.Motions.Systems
{
    public class GetNextMotionConfigSystem : IExecuteSystem
    {
        private readonly IMotionsFactory _motionsFactory;
        private readonly IAnimationFactory _animationFactory;
        private readonly IMovementFactory _movementFactory;
        private readonly IGroup<GameEntity> _motionQueue;
        private readonly IGroup<GameEntity> _motions;
        private readonly List<GameEntity> _buffer = new(16);

        public GetNextMotionConfigSystem(GameContext game, IMotionsFactory motionsFactory)
        {
            _motionsFactory = motionsFactory;

            _motionQueue = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Id,
                        GameMatcher.AnimatorId,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.MotionQueue,
                        GameMatcher.MoveNext
                    )
                    .NoneOf(GameMatcher.Empty));
        }

        public void Execute()
        {
            foreach (var motionQueue in _motionQueue.GetEntities(_buffer))
            {
                var config = motionQueue.MotionQueue.Dequeue();
                
                _motionsFactory
                    .CreateMotion(
                        config,
                        motionQueue.AnimatorId,
                        motionQueue.ProducerId,
                        motionQueue.TargetId)
                    .AddMotionLinkedQueueId(motionQueue.Id);

                motionQueue.isMoveNext = false;
            }
        }
    }
}
