using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.AnimationEvents.Systems
{
    public class InvokeAnimationEventsWithoutHashCodeSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _animationEvents;
        private readonly List<GameEntity> _buffer = new(64);

        public InvokeAnimationEventsWithoutHashCodeSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _animationEvents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationEvent,
                    GameMatcher.TimeLeft
                )
                .NoneOf(
                    GameMatcher.Invoked,
                    GameMatcher.HashCode));
        }

        public void Execute()
        {
            foreach (var animationEvent in _animationEvents.GetEntities(_buffer))
            {
                animationEvent.ReplaceTimeLeft(animationEvent.TimeLeft - _time.DeltaTime);

                if (animationEvent.TimeLeft <= 0f)
                    animationEvent.isInvoked = true;
            }
        }
    }
}
