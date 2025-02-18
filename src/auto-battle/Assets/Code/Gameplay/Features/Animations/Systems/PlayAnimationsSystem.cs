using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class PlayAnimationsSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _animations;
        private readonly List<GameEntity> _buffer = new(24);

        public PlayAnimationsSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _animations = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Animation)
                .NoneOf(GameMatcher.AnimationComplete));
        }

        public void Execute()
        {
            foreach (var animation in _animations.GetEntities(_buffer))
            {
                animation.ReplaceTimeLeft(animation.TimeLeft - _time.DeltaTime);

                if (animation.TimeLeft <= 0f)
                    animation.isAnimationComplete = true;
            }
        }
    }
}
