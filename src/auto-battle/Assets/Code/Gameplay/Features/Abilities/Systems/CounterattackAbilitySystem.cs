using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class CounterattackAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _producers;
        private readonly IGroup<GameEntity> _targetAbilities;
        private readonly List<GameEntity> _buffer = new(16);

        public CounterattackAbilitySystem(GameContext game)
        {
            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.CounterattackAbility,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                ability.isActive = true;
            }
        }
    }
}
