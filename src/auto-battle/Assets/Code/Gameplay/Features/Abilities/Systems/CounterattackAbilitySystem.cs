using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class CounterattackAbilitySystem : IExecuteSystem
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(24);

        public CounterattackAbilitySystem(GameContext game, IAnimationFactory animationFactory)
        {
            _animationFactory = animationFactory;

            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.CounterattackAbility,
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
                    _animationFactory.CreateAnimation(animationSetup, ability.ProducerId, ability.TargetId);

                ability.isActive = true;
            }
        }
    }
}
