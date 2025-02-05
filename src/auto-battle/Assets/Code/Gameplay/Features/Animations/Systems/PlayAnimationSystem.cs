using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class PlayAnimationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animations;
        private readonly IGroup<GameEntity> _fighters;
        private readonly List<GameEntity> _buffer = new(32);

        public PlayAnimationSystem(GameContext game)
        {
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.AnimationTypeId,
                    GameMatcher.ProducerId
                )
                .NoneOf(GameMatcher.AnimationStarted));
            
            _fighters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.Id,
                    GameMatcher.FighterAnimator
                ));
        }

        public void Execute()
        {
            foreach (var animation in _animations.GetEntities(_buffer))
            foreach (var fighter in _fighters)
            {
                if (animation.ProducerId == fighter.Id)
                    animation.AddAnimationTime(fighter.FighterAnimator.PlayAnimationWithTypeId(animation.AnimationTypeId));
            }
        }
    }
}
