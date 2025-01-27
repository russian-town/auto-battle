using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class StartAnimationWithAnimationTimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animation;
        private readonly List<GameEntity> _buffer = new(32);

        public StartAnimationWithAnimationTimeSystem(GameContext game)
        {
            _animation = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Animation,
                        GameMatcher.AnimationTime,
                        GameMatcher.AnimationCurrentTime
                    )
                    .NoneOf(GameMatcher.AnimationStarted));
        }

        public void Execute()
        {
            foreach (var animation in _animation.GetEntities(_buffer))
                animation.isAnimationStarted = true;
        }
    }
}
