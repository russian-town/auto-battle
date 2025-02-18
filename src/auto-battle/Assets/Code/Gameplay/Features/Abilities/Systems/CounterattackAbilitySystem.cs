using System.Collections.Generic;
using Code.Gameplay.Features.AnimationEvents.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class CounterattackAbilitySystem : IExecuteSystem
    {
        private readonly IAnimationEventFactory _animationEventFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _producers;
        private readonly IGroup<GameEntity> _targetAbilities;
        private readonly List<GameEntity> _buffer = new(16);

        public CounterattackAbilitySystem(GameContext game, IAnimationEventFactory animationEventFactory)
        {
            _animationEventFactory = animationEventFactory;

            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.CounterattackAbility,
                        GameMatcher.AnimationEventSetups,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId
                    )
                    .NoneOf(GameMatcher.Active));

            _producers = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Id,
                        GameMatcher.FighterAnimator
                    ));
            
            _targetAbilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Ability,
                        GameMatcher.TargetId,
                        GameMatcher.AttackAvailable
                    ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var producer in _producers)
            foreach (var targetAbility in _targetAbilities)
            {
                if (ability.ProducerId != producer.Id)
                    continue;

                if(targetAbility.TargetId != producer.Id)
                    continue;
                
                foreach (var animationEventSetup in ability.AnimationEventSetups)
                {
                    _animationEventFactory.CreateAnimationEvent(
                        animationEventSetup,
                        ability.ProducerId,
                        ability.TargetId);
                }

                producer.FighterAnimator.PlayCounterattack();
                ability.isActive = true;
            }
        }
    }
}
