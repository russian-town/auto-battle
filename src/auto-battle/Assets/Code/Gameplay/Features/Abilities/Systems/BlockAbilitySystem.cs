using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class BlockAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _blockAbilities;
        private readonly IGroup<GameEntity> _attackAbilities;
        private readonly List<GameEntity> _buffer = new(16);

        public BlockAbilitySystem(GameContext game)
        {
            _blockAbilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Ability,
                        GameMatcher.BlockAbility,
                        GameMatcher.Id,
                        GameMatcher.ProducerId
                    )
                    .NoneOf(GameMatcher.Active));
            
            _attackAbilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Ability,
                        GameMatcher.DefaultAttackAbility,
                        GameMatcher.Id,
                        GameMatcher.TargetId,
                        GameMatcher.EffectValue
                    ));
        }

        public void Execute()
        {
            foreach (var blockAbility in _blockAbilities.GetEntities(_buffer))
            foreach (var attackAbility in _attackAbilities)
            {
                if(blockAbility.ProducerId != attackAbility.TargetId)
                    continue;

                attackAbility.ReplaceEffectValue(0);
                blockAbility.isActive = true;
            }
        }
    }
}
