using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class InvokeAnimationEventsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animationEvents;
        private readonly IGroup<GameEntity> _parentAnimation;
        private readonly List<GameEntity> _buffer = new(32);

        public InvokeAnimationEventsSystem(GameContext game)
        {
            _animationEvents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationEvent,
                    GameMatcher.TargetFrame
                    )
                .NoneOf(GameMatcher.Invoked));
            
            _parentAnimation = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.CurrentFrame,
                    GameMatcher.Id
                    ));
        }

        public void Execute()
        {
            foreach (var animationEvent in _animationEvents.GetEntities(_buffer))
            foreach (var parentAnimation in _parentAnimation)
            {
                if(animationEvent.AnimationLinkedId != parentAnimation.Id)
                    continue;

                if (animationEvent.TargetFrame <= parentAnimation.CurrentFrame)
                    animationEvent.isInvoked = true;
            }
        }
    }
}
