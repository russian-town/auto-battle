using System.Collections.Generic;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Abilities.System
{
    public class BlockAbilitySystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(4);

        public BlockAbilitySystem(
            GameContext game,
            IStaticDataService staticDataService,
            IArmamentFactory armamentFactory)
        {
            _staticDataService = staticDataService;
            _armamentFactory = armamentFactory;

            _abilities = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.BlockAbility,
                        GameMatcher.CooldownUp
                    ));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                _armamentFactory.CreateBlock(ability.AbilityId, 1);
                ability.PutOnCooldown(_staticDataService.GetAbilityConfig(AbilityId.Block).Cooldown);
            }
        }
    }
}
