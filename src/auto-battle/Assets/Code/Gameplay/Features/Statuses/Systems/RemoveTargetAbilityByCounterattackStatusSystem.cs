using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class RemoveTargetAbilityByCounterattackStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new(32);

        public RemoveTargetAbilityByCounterattackStatusSystem(GameContext game)
        {
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.DamageAbsorption,
                    GameMatcher.CounterattackStatus,
                    GameMatcher.ProducerId
                ));
            
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.DefaultAttackAbility,
                    GameMatcher.TargetId,
                    GameMatcher.ProducerId
                ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var status in _statuses)
            {
                if (ability.TargetId == status.ProducerId)
                    ability.isActive = true;
            }
        }
    }
}
