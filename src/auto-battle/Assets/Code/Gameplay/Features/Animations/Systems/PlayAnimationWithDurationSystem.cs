using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class PlayAnimationWithDurationSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _animation;
        private readonly List<GameEntity> _buffer = new(32);

        public PlayAnimationWithDurationSystem(GameContext game, ITimeService time)
        {
            _time = time;

            _animation = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Animation,
                        GameMatcher.AnimationTime,
                        GameMatcher.AnimationCurrentTime,
                        GameMatcher.AnimationStarted
                    )
                    .NoneOf(GameMatcher.AnimationEnded));
        }

        public void Execute()
        {
            foreach (var animation in _animation.GetEntities(_buffer))
            {
                animation.ReplaceAnimationCurrentTime(animation.AnimationCurrentTime + _time.DeltaTime);

                if (animation.AnimationCurrentTime < animation.AnimationTime)
                    continue;

                animation.RemoveAnimationTime();
                animation.RemoveAnimationCurrentTime();
                animation.isAnimationStarted = false;
                animation.isAnimationEnded = true;
            }
        }
    }
}
