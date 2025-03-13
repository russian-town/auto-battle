using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Services;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class CleanupCompletedAbilitiesSystem : ICleanupSystem
    {
        private readonly IAbilityRandomService _abilityRandomService;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public CleanupCompletedAbilitiesSystem(GameContext game, IAbilityRandomService abilityRandomService)
        {
            _abilityRandomService = abilityRandomService;
            
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.Completed
                    ));
        }

        public void Cleanup()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                ability.Destroy();
                _abilityRandomService.Cleanup();
            }
        }
    }
}
