using System.Collections.Generic;
using Code.Gameplay.Features.AnimationEvents.Factory;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class CreateAnimationEventsByAnimationsSystem : IExecuteSystem
    {
        private readonly IAnimationEventFactory _animationEventFactory;
        private readonly IGroup<GameEntity> _animations;
        private readonly List<GameEntity> _buffer = new(32);

        public CreateAnimationEventsByAnimationsSystem(GameContext game, IAnimationEventFactory animationEventFactory)
        {
            _animationEventFactory = animationEventFactory;
            
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.Id,
                GameMatcher.Animation,
                GameMatcher.ProducerId,
                GameMatcher.TargetId,
                GameMatcher.AnimationEventConfigs
                )
                .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var animation in _animations.GetEntities(_buffer))
            {
                foreach (var animationEventSetup in animation.AnimationEventConfigs)
                {
                    _animationEventFactory.CreateAnimationEvent(
                        animationEventSetup,
                        animation.Id,
                        animation.ProducerId, 
                        animation.TargetId);
                }

                animation.isActive = true;
            }
        }
    }
}
