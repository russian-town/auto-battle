using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class CompleteMoveToTargetAnimationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animations;
        private readonly IGroup<GameEntity> _fighters;
        private readonly List<GameEntity> _buffer = new(32);

        public CompleteMoveToTargetAnimationSystem(GameContext game)
        {
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.MoveToTargetAnimation,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetDistance,
                    GameMatcher.AnimationStarted
                ));
            
            _fighters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.Id,
                    GameMatcher.FighterAnimator,
                    GameMatcher.DistanceToTarget
                ));
        }

        public void Execute()
        {
            foreach (var animation in _animations.GetEntities(_buffer))
            foreach (var fighter in _fighters)
            {
                if(animation.ProducerId != fighter.Id)
                    continue;

                if (fighter.DistanceToTarget <= animation.TargetDistance)
                {
                    fighter.FighterAnimator.PlayIdle();
                    fighter.isMoving = false;
                    animation.isAnimationStarted = false;
                    animation.isAnimationEnded = true;
                }
            }
        }
    }
}
