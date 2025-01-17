using System.Collections.Generic;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Factory;
using Entitas;

namespace Code.Gameplay.Features.Fight.Systems
{
    public class CreateAbilitiesByFighters : IExecuteSystem
    {
        private readonly IAbilityFactory _abilityFactory;
        private readonly IGroup<GameEntity> _fights;
        private readonly List<GameEntity> _buffer = new(2);

        public CreateAbilitiesByFighters(GameContext game, IAbilityFactory abilityFactory)
        {
            _abilityFactory = abilityFactory;
            
            _fights = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fight,
                    GameMatcher.TargetId,
                    GameMatcher.ProducerId,
                    GameMatcher.CooldownUp
                    ));
        }

        public void Execute()
        {
            foreach (var fight in _fights.GetEntities(_buffer))
            {
                var ability = _abilityFactory.CreateAbility(
                    AbilityTypeId.DefaultAttack,
                    fight.ProducerId,
                    fight.TargetId);

                fight.isCooldownUp = false;
                fight.AddCooldownLeft(ability.Cooldown);
            }
        }
    }
}
