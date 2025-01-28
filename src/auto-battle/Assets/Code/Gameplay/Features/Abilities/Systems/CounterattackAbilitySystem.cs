using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Factory;
using Code.Gameplay.Features.Statuses.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class CounterattackAbilitySystem : IExecuteSystem
    {
        private readonly IStatusFactory _statusFactory;
        private readonly IAnimationFactory _animationFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(24);

        public CounterattackAbilitySystem(GameContext game, IStatusFactory statusFactory, IAnimationFactory animationFactory)
        {
            _statusFactory = statusFactory;
            _animationFactory = animationFactory;

            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.CounterattackAbility,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.StatusSetups
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                foreach (var statusSetup in ability.StatusSetups)
                    _statusFactory.CreateStatus(statusSetup, ability.ProducerId, ability.TargetId);

                foreach (var animationSetup in ability.AnimationSetups)
                    _animationFactory.CreateAnimation(animationSetup, ability.ProducerId, ability.TargetId);
                
                ability.isActive = true;
            }
        }
    }
}
