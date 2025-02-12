using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class TimeAnimationsSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _animations;
        private readonly List<GameEntity> _buffer = new(16);

        public TimeAnimationsSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.AnimationHash,
                GameMatcher.CurrentTime,
                GameMatcher.Length
                )
                .NoneOf(GameMatcher.AnimationEnded));
        }

        public void Execute()
        {
            foreach (var animation in _animations.GetEntities(_buffer))
            {
                animation.ReplaceCurrentTime(animation.CurrentTime + _time.DeltaTime);
                
                if (animation.CurrentTime >= animation.Length)
                    animation.isAnimationEnded = true;
            }
        }
    }
}
