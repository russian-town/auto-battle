﻿using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Configs;
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

        public GameEntity CreateAbility(AbilityConfig config, int producerId, int targetId)
        {
            //var config = _staticDataService.GetAbilityConfig(typeId);
            var ability = CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .With(x => x.isAbility = true)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddStatusSetups(config.StatusSetups)
                .AddEffectSetups(config.EffectSetups);
            
            switch (config.AbilityTypeId)
            {
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

        private GameEntity CreateCounterattack(GameEntity entity) =>
            entity.With(x => x.isCounterattack = true);

        private GameEntity CreateBlock(GameEntity entity) =>
            entity.With(x => x.isBlock = true);

        private GameEntity CreateDodge(GameEntity entity) =>
            entity.With(x => x.isDodge = true);

        private GameEntity CreateDoubleStrike(GameEntity entity) =>
            entity.With(x => x.isDoubleStrike = true);
    }
}
