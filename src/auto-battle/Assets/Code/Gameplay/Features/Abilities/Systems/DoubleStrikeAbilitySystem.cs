using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DoubleStrikeAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public DoubleStrikeAbilitySystem(GameContext game)
        {
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DoubleStrikeAbility,
                    GameMatcher.Id,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.CooldownUp
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
