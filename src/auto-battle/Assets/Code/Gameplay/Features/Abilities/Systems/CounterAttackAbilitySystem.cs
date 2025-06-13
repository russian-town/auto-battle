using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class CounterAttackAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _targetAbilities;
        private readonly List<GameEntity> _buffer = new(16);

        public CounterAttackAbilitySystem(GameContext game)
        {
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CounterattackAbility,
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
                
                ability.isActive = true;
            }
        }
    }
}
