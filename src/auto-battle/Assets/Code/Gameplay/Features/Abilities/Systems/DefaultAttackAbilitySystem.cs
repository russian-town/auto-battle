using System.Collections.Generic;
using Code.Gameplay.Features.Motions.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DefaultAttackAbilitySystem : IExecuteSystem
    {
        private readonly IMotionsFactory _motionsFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public DefaultAttackAbilitySystem(GameContext game, IMotionsFactory motionsFactory)
        {
            _motionsFactory = motionsFactory;
            
            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.DefaultAttackAbility,
                        GameMatcher.Id,
                        GameMatcher.MotionConfigs,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                _motionsFactory.CreateMotionQueue(
                    ability.MotionConfigs,
                    ability.ProducerId,
                    ability.ProducerId,
                    ability.TargetId);
                
                ability.isActive = true;
            }
        }
    }
}
