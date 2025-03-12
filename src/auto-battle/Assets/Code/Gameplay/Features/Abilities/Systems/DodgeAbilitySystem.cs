using System.Collections.Generic;
using Code.Gameplay.Features.AnimationsQueue.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DodgeAbilitySystem : IExecuteSystem
    {
        private readonly IAnimationsQueueFactory _animationsQueueFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _animationEvents;
        private readonly List<GameEntity> _buffer = new(16);

        public DodgeAbilitySystem(GameContext game, IAnimationsQueueFactory animationsQueueFactory)
        {
            _animationsQueueFactory = animationsQueueFactory;

            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.DodgeAbility,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId
                )
                .NoneOf(GameMatcher.Active));
            
            _animationEvents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationEvent,
                    GameMatcher.TargetId,
                    GameMatcher.EffectSetups
                ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var animationEvent in _animationEvents)
            {
                if (ability.ProducerId != animationEvent.TargetId)
                    continue;

                _animationsQueueFactory.CreateAnimationQueue(
                    ability.AnimationSetups,
                    ability.ProducerId,
                    ability.TargetId);
                
                ability.isActive = true;
            }
        }
    }
}
