using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class CleanupInterruptedAbilityChildesSystems : ICleanupSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(64);

        public CleanupInterruptedAbilityChildesSystems(GameContext game)
        {
            _game = game;
            
            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Ability,
                        GameMatcher.Id,
                        GameMatcher.Interrupted
                    ));
        }

        public void Cleanup()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            foreach (var child in _game.GetEntitiesWithParentAbilityId(ability.Id))
            {
                child.isDestructed = true;
            }
        }
    }
}
