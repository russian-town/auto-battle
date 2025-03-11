using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DodgeAbilitySystem : IExecuteSystem
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _animationEvents;
        private readonly List<GameEntity> _buffer = new(16);

        public DodgeAbilitySystem(GameContext game, IAnimationFactory animationFactory)
        {
            _animationFactory = animationFactory;

            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.DodgeAbility,
                    GameMatcher.Id
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
            foreach (var animationSetup in ability.AnimationSetups)
            {
                if (ability.ProducerId != animationEvent.TargetId)
                    continue;

                _animationFactory.CreateAnimation(animationSetup, ability.ProducerId, ability.TargetId);
                ability.isActive = true;
            }
        }
    }
}
