using System.Collections.Generic;
using Code.Gameplay.Common.Abilities;
using Code.Gameplay.Features.Abilities.Factory;
using Entitas;

namespace Code.Gameplay.Features.Fight.Systems
{
    public class ProcessFightSystem : IExecuteSystem
    {
        private readonly IAbilityService _abilityService;
        private readonly IAbilityFactory _abilityFactory;
        private readonly IGroup<GameEntity> _turns;
        private readonly IGroup<GameEntity> _fighters;
        private readonly List<GameEntity> _buffer = new(4);

        public ProcessFightSystem(GameContext game, IAbilityService abilityService, IAbilityFactory abilityFactory)
        {
            _abilityService = abilityService;
            _abilityFactory = abilityFactory;

            _turns = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Turn,
                    GameMatcher.TargetId
                    ));
            
            _fighters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.Id,
                    GameMatcher.TargetId
                    ));
        }

        public void Execute()
        {
            foreach (var turn in _turns.GetEntities(_buffer))
            foreach (var fighter in _fighters)
            {
                if (turn.TargetId != fighter.Id)
                    continue;
                
                var config = _abilityService.GetRandomAbilities();

                if (config == null)
                    continue;
                    
                _abilityFactory.CreateAbility(config, fighter.Id, fighter.TargetId);
                turn.isDestructed = true;
            }
        }
    }
}
