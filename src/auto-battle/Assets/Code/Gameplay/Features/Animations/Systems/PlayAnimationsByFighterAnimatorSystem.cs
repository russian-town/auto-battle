using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class PlayAnimationsByFighterAnimatorSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animations;
        private readonly IGroup<GameEntity> _fighterAnimators;
        private readonly List<GameEntity> _buffer = new(32);

        public PlayAnimationsByFighterAnimatorSystem(GameContext game)
        {
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.HashCode,
                    GameMatcher.DurationTime,
                    GameMatcher.TransitionTime
                    )
                .NoneOf(GameMatcher.Started));
            
            _fighterAnimators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.FighterAnimator
                    ));
        }

        public void Execute()
        {
            foreach (var animation in _animations.GetEntities(_buffer))
            foreach (var fighterAnimator in _fighterAnimators)
            {
                if(animation.ProducerId != fighterAnimator.Id)
                    continue;
                
                fighterAnimator.FighterAnimator
                    .Play(animation.HashCode, animation.DurationTime, animation.TransitionTime);
                
                animation.isStarted = true;
            }
        }
    }
}
