using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Abilities.Factory
{
    public class AbilityFactory : IAbilityFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;

        public AbilityFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateAbility(AbilityTypeId typeId, int producerId, int targetId)
        {
            var config = _staticDataService.GetAbilityConfig(typeId);

            var ability = CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddAbilityTypeId(config.AbilityTypeId)
                .With(x => x.isAbility = true)
                .With(x => x.AddEffectSetups(config.EffectSetups), when: !config.EffectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(config.StatusSetups), when: !config.StatusSetups.IsNullOrEmpty())
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                ;
            
            switch (config.AbilityTypeId)
            {
                case AbilityTypeId.DefaultAttack:
                    return CreateDefaultAttack(ability);
                case AbilityTypeId.Counterattack:
                    return CreateCounterattack(ability);
                case AbilityTypeId.Block:
                    return CreateBlock(ability);
                case AbilityTypeId.Dodge:
                    return CreateDodge(ability);
                case AbilityTypeId.DoubleStrike:
                    return CreateDoubleStrike(ability);
            }

            throw new ArgumentException($"{config.AbilityTypeId}");
        }

        private GameEntity CreateDefaultAttack(GameEntity entity) =>
            entity.With(x => x.isDefaultAttackAbility = true);

        private GameEntity CreateCounterattack(GameEntity entity) =>
            entity.With(x => x.isCounterattackAbility = true);

        private GameEntity CreateBlock(GameEntity entity) =>
            entity.With(x => x.isBlockAbility = true);

        private GameEntity CreateDodge(GameEntity entity) =>
            entity.With(x => x.isDodgeAbility = true);

        private GameEntity CreateDoubleStrike(GameEntity entity) =>
            entity.With(x => x.isDoubleStrikeAbility = true);
    }
}
