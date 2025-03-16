using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class CleanupInterruptedAbilitiesSystems : ICleanupSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(64);

        public CleanupInterruptedAbilitiesSystems(GameContext game)
        {
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.Interrupted
                ));
        }

        public void Cleanup()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                ability.Destroy();
            }
        }
    }
}
