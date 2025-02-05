using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class CompleteMoveToStartPointAnimationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animations;
        private readonly IGroup<GameEntity> _fighters;
        private readonly List<GameEntity> _buffer = new(32);

        public CompleteMoveToStartPointAnimationSystem(GameContext game)
        {
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.AnimationStarted,
                    GameMatcher.TargetDistance,
                    GameMatcher.MoveToStartPointAnimation,
                    GameMatcher.ProducerId
                ));
            
            _fighters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.Id,
                    GameMatcher.DistanceToStartPoint,
                    GameMatcher.FighterAnimator
                ));
        }

        public void Execute()
        {
            foreach (var animation in _animations.GetEntities(_buffer))
            foreach (var fighter in _fighters)
            {
                if(animation.ProducerId != fighter.Id)
                    continue;

                if (fighter.DistanceToStartPoint <= animation.TargetDistance)
                {
                    fighter.isMoving = false;
                    fighter.FighterAnimator.PlayIdle();
                    animation.isAnimationStarted = false;
                    animation.isAnimationEnded = true;
                }
            }
        }
    }
}
