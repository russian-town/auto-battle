using System.Collections.Generic;
using Code.Gameplay.Features.AnimationsQueue.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class BlockAbilitySystem : IExecuteSystem
    {
        private readonly IAnimationsQueueFactory _animationsQueueFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public BlockAbilitySystem(GameContext game, IAnimationsQueueFactory animationsQueueFactory)
        {
            _animationsQueueFactory = animationsQueueFactory;

            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Ability,
                        GameMatcher.Id,
                        GameMatcher.Block,
                        GameMatcher.TargetId,
                        GameMatcher.ProducerId,
                        GameMatcher.CooldownUp
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                _animationsQueueFactory.CreateAnimationQueue(
                    ability.AnimationSetups,
                    ability.ProducerId,
                    ability.TargetId)
                    .AddParentAbilityId(ability.Id);

                ability.isActive = true;
            }
        }
    }
}
