using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Abilities.Services;
using Entitas;

namespace Code.Gameplay.Features.Fighter.Systems
{
    public class CreateAbilityByFightersSystem : IExecuteSystem
    {
        private readonly IAbilityFactory _abilityFactory;
        private readonly IAbilityRandomService _abilityRandomService;
        private readonly IGroup<GameEntity> _fighters;

        public CreateAbilityByFightersSystem(
            GameContext game,
            IAbilityFactory abilityFactory,
            IAbilityRandomService abilityRandomService)
        {
            _abilityFactory = abilityFactory;
            _abilityRandomService = abilityRandomService;

            _fighters = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Fighter,
                        GameMatcher.Mana
                    ));
        }

        public void Execute()
        {
            foreach (var fighter in _fighters)
            {
                var config = _abilityRandomService.GetRandomAbility(fighter.BaseAbilities);
                _abilityFactory.CreateAbility(config.AbilityTypeId, fighter.Id, fighter.TargetId);
                fighter.ReplaceMana(fighter.Mana - config.ManaCost);
            }
        }
    }
}
