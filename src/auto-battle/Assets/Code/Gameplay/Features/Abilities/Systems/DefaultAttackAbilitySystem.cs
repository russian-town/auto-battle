using System.Collections.Generic;
using Code.Gameplay.Features.AnimationEvents.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DefaultAttackAbilitySystem : IExecuteSystem
    {
        private readonly IAnimationEventFactory _animationEventFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _producers;
        private readonly List<GameEntity> _buffer = new(16);

        public DefaultAttackAbilitySystem(GameContext game, IAnimationEventFactory animationEventFactory)
        {
            _animationEventFactory = animationEventFactory;

            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.DefaultAttackAbility,
                        GameMatcher.AnimationEventSetups,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.AttackAvailable
                    )
                    .NoneOf(GameMatcher.Active));

            _producers = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Id,
                        GameMatcher.FighterAnimator
                    ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var producer in _producers)
            {
                if (ability.ProducerId != producer.Id)
                    continue;

                foreach (var animationEventSetup in ability.AnimationEventSetups)
                {
                    _animationEventFactory.CreateAnimationEvent(
                        animationEventSetup,
                        ability.ProducerId,
                        ability.TargetId);
                }
                
                producer.FighterAnimator.PlayDefaultAttack();
                ability.isActive = true;
            }
        }
    }
}
