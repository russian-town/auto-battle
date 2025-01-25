using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class CleanupAbilitySystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(24);

        public CleanupAbilitySystem(GameContext game)
        {
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.Active
                    ));
        }

        public void Cleanup()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
                ability.Destroy();
        }
    }
}
