using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DefaultAttackAbilitySystem : IExecuteSystem
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public DefaultAttackAbilitySystem(GameContext game, IAnimationFactory animationFactory)
        {
            _animationFactory = animationFactory;
            
            _abilities = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.DefaultAttackAbility,
                        GameMatcher.Id,
                        GameMatcher.AnimationSetups,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.CurrentAnimationIndex
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                _animationFactory
                        .CreateAnimation(
                            ability.AnimationSetups[ability.CurrentAnimationIndex],
                            ability.ProducerId,
                            ability.TargetId)
                        .AddParentAbilityId(ability.Id);

                ability.isActive = true;
            }
        }
    }
}
