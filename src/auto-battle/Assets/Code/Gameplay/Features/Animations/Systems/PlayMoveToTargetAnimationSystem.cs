using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class PlayMoveToTargetAnimationSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _animations;
        private readonly List<GameEntity> _buffer = new(32);

        public PlayMoveToTargetAnimationSystem(GameContext game)
        {
            _game = game;
            
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.MoveToTargetAnimation,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId
                )
                .NoneOf(GameMatcher.AnimationStarted));
        }

        public void Execute()
        {
            foreach (var animation in _animations.GetEntities(_buffer))
            {
                var target = _game.GetEntityWithId(animation.TargetId);
                var producer = _game.GetEntityWithId(animation.ProducerId);
                var direction = target.WorldPosition - producer.WorldPosition;
                producer.ReplaceDirection(direction.normalized);
                producer.FighterAnimator.PlayMoveForward();
                producer.isMoving = true;
                animation.isAnimationStarted = true;
            }
        }
    }
}
