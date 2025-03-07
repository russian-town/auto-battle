using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Factory;
using Code.Gameplay.Features.Motions.Factory;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Movement.Factory;
using Entitas;

namespace Code.Gameplay.Features.Motions.Systems
{
    public class GetNextMotionConfigSystem : IExecuteSystem
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly IMovementFactory _movementFactory;
        private readonly IGroup<GameEntity> _motions;
        private readonly List<GameEntity> _buffer = new(16);

        public GetNextMotionConfigSystem(
            GameContext game,
            IAnimationFactory animationFactory,
            IMovementFactory movementFactory)
        {
            _animationFactory = animationFactory;
            _movementFactory = movementFactory;

            _motions = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.AnimatorId,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.MotionQueue,
                        GameMatcher.Progress,
                        GameMatcher.ProgressFilled
                    )
                    .NoneOf(GameMatcher.Empty));
        }

        public void Execute()
        {
            foreach (var motion in _motions.GetEntities(_buffer))
            {
                var config = motion.MotionQueue.Dequeue();

                _animationFactory.CreateAnimation(
                        config.AnimationSetup,
                        motion.AnimatorId,
                        motion.ProducerId,
                        motion.TargetId)
                    .AddMotionQueueLinkedId(motion.Id);

                if (config.DirectionType == DirectionType.Movable)
                    _movementFactory.CreateMovement(
                        config.MovementSetup,
                        motion.AnimatorId,
                        motion.ProducerId,
                        motion.TargetId
                        ).AddMotionQueueLinkedId(motion.Id);

                motion.ReplaceProgress(0f);
                motion.isProgressFilled = false;
            }
        }
    }
}
