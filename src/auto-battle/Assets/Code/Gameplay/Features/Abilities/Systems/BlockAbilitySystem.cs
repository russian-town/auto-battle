using System.Collections.Generic;
using Code.Gameplay.Features.AnimationEvents.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class BlockAbilitySystem : IExecuteSystem
    {
        private readonly IAnimationEventFactory _animationEventFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(32);

        public BlockAbilitySystem(GameContext game, IAnimationEventFactory animationEventFactory)
        {
            _animationEventFactory = animationEventFactory;
            
            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Ability,
                        GameMatcher.BlockAbility,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.AnimationEventSetups
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                foreach (var animationEventSetup in ability.AnimationEventSetups)
                {
                    _animationEventFactory.CreateAnimationEvent(
                        animationEventSetup,
                        ability.ProducerId,
                        ability.TargetId);
                }

                ability.isActive = true;
            }
        }
    }
}
