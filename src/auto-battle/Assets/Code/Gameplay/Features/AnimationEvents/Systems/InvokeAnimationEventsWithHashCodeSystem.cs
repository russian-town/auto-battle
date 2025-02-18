using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.AnimationEvents.Systems
{
    public class InvokeAnimationEventsWithHashCodeSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _animationEvents;
        private readonly IGroup<GameEntity> _animations;
        private readonly List<GameEntity> _buffer = new(64);

        public InvokeAnimationEventsWithHashCodeSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.HashCode
                    ));
            
            _animationEvents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationEvent,
                    GameMatcher.HashCode,
                    GameMatcher.TimeLeft
                    )
                .NoneOf(GameMatcher.Invoked));
        }

        public void Execute()
        {
            foreach (var animationEvent in _animationEvents.GetEntities(_buffer))
            foreach (var animation in _animations)
            {
                if (animation.HashCode != animationEvent.HashCode)
                    continue;

                animationEvent.ReplaceTimeLeft(animationEvent.TimeLeft - _time.DeltaTime);

                if (animationEvent.TimeLeft <= 0f)
                    animationEvent.isInvoked = true;
            }
        }
    }
}
