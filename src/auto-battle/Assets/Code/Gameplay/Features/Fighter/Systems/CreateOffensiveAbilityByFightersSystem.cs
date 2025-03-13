using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Abilities.Services;
using Entitas;

namespace Code.Gameplay.Features.Fighter.Systems
{
    public class CreateOffensiveAbilityByFightersSystem : IExecuteSystem
    {
        private readonly IAbilityRandomService _abilityRandomService;
        private readonly IAbilityFactory _abilityFactory;
        private readonly IGroup<GameEntity> _fighters;
        private readonly List<GameEntity> _buffer = new(2);

        public CreateOffensiveAbilityByFightersSystem(
            GameContext game,
            IAbilityRandomService abilityRandomService,
            IAbilityFactory abilityFactory)
        {
            _abilityRandomService = abilityRandomService;
            _abilityFactory = abilityFactory;
            
            _fighters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.Id,
                    GameMatcher.TargetId,
                    GameMatcher.Mana,
                    GameMatcher.ReadyToNextTurn
                    ));
        }

        public void Execute()
        {
            foreach (var fighter in _fighters.GetEntities(_buffer))
            {
                if (fighter.Mana <= 0)
                    continue;

                var config = _abilityRandomService.GetOffensiveAbility(fighter.BaseAbilities);
                _abilityFactory.CreateAbility(config.AbilityTypeId, fighter.Id, fighter.TargetId);
                fighter.ReplaceMana(fighter.Mana - config.ManaCost);
                fighter.isReadyToNextTurn = false;
            }
        }
    }
}
