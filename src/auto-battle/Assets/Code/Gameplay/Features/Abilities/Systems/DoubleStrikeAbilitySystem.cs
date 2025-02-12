using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DoubleStrikeAbilitySystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(32);

        public DoubleStrikeAbilitySystem(GameContext game)
        {
            _game = game;

            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.DoubleStrikeAbility,
                        GameMatcher.AbilityTypeId,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId
                    )
                    .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                var producer = _game.GetEntityWithId(ability.ProducerId);
                producer.FighterAnimator.PlayDoubleStrike();
                ability.isActive = true;
            }
        }
    }
}
