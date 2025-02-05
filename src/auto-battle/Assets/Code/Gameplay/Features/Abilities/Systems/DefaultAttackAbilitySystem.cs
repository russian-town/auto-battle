using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Factory;
using Code.Gameplay.Features.Effect.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DefaultAttackAbilitySystem : IExecuteSystem
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _counterattacks;
        private readonly IGroup<GameEntity> _animations;
        private readonly List<GameEntity> _buffer = new(32);

        public DefaultAttackAbilitySystem(GameContext game, IAnimationFactory animationFactory)
        {
            _animationFactory = animationFactory;

            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.DefaultAttackAbility,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.AnimationSetups
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                foreach (var animationSetup in ability.AnimationSetups)
                    _animationFactory
                        .CreateAnimation(animationSetup, ability.ProducerId, ability.TargetId);
                
                ability.isActive = true;
            }
        }
    }
}
