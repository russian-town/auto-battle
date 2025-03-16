using System.Collections.Generic;
using Code.Gameplay.Features.AnimationsQueue.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class CounterAttackAbilitySystem : IExecuteSystem
    {
        private readonly IAnimationsQueueFactory _animationsQueueFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _animations;
        private readonly List<GameEntity> _buffer = new(16);

        public CounterAttackAbilitySystem(GameContext game, IAnimationsQueueFactory animationsQueueFactory)
        {
            _animationsQueueFactory = animationsQueueFactory;
            
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Counterattack,
                    GameMatcher.AnimationSetups,
                    GameMatcher.Id,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId
                )
                .NoneOf(GameMatcher.Active));
            
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.Idle,
                    GameMatcher.ProducerId
                ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var animation in _animations)
            {
                if(animation.ProducerId != ability.TargetId)
                    continue;
                
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
