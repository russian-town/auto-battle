using System.Collections.Generic;
using Code.Gameplay.Features.AnimationsQueue.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class CounterAttackAbilitySystem : IExecuteSystem
    {
        private readonly IAnimationsQueueFactory _animationsQueueFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _targetAbilities;
        private readonly List<GameEntity> _buffer = new(16);

        public CounterAttackAbilitySystem(GameContext game, IAnimationsQueueFactory animationsQueueFactory)
        {
            _animationsQueueFactory = animationsQueueFactory;
            
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CounterattackAbility,
                    GameMatcher.AnimationSetups,
                    GameMatcher.Id,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId
                )
                .NoneOf(GameMatcher.Active));
            
            _targetAbilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DefaultAttackAbility,
                    GameMatcher.Id,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId
                ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var targetAbility in _targetAbilities)
            {
                if(targetAbility.ProducerId != ability.TargetId)
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
