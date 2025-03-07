using System.Collections.Generic;
using Code.Gameplay.Features.Movement.Factory;
using Entitas;

namespace Code.Gameplay.Features.Motions.Systems
{
    public class CreateMovementByMotionsSystem : IExecuteSystem
    {
        private readonly IMovementFactory _movementFactory;
        private readonly IGroup<GameEntity> _motions;
        private readonly List<GameEntity> _buffer = new(16);

        public CreateMovementByMotionsSystem(GameContext game, IMovementFactory movementFactory)
        {
            _movementFactory = movementFactory;

            _motions = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Motion,
                        GameMatcher.Id,
                        GameMatcher.AnimatorId,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.MovementConfig
                    )
                    .NoneOf(GameMatcher.Affected));
        }

        public void Execute()
        {
            foreach (var motion in _motions.GetEntities(_buffer))
            {
                _movementFactory
                    .CreateMovement(
                        motion.MovementConfig,
                        motion.AnimatorId,
                        motion.ProducerId,
                        motion.TargetId)
                    .AddMotionLinkedId(motion.Id)
                    .AddProgress(0);

                motion.isAffected = true;
            }
        }
    }
}
