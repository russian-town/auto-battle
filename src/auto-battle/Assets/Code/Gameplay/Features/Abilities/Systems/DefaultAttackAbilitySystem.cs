using System.Collections.Generic;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DefaultAttackAbilitySystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticData;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public DefaultAttackAbilitySystem(
            GameContext game,
            IStaticDataService staticData)
        {
            _staticData = staticData;

            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.DefaultAttackAbility,
                        GameMatcher.Id,
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
