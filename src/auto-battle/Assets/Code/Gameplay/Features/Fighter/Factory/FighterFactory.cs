using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Fighter.Factory
{
    public class FighterFactory : IFighterFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;

        public FighterFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateFighter(Vector3 at, Quaternion rotation, FighterTypeId fighterTypeId)
        {
            var config = _staticDataService.GetFighterConfig();
            var statByType = config.GetStats();

            return CreateEntity.Empty("Fighter")
                    .AddId(_identifiers.Next())
                    .With(x => x.isFighter = true)
                    .AddWorldPosition(at)
                    .AddWorldRotation(rotation)
                    .AddDamage(statByType[Stats.Damage])
                    .AddCurrentHealth(statByType[Stats.MaxHealth])
                    .AddMaxHealth(statByType[Stats.MaxHealth])
                    .AddMana(0)
                    .AddBaseStats(statByType)
                    .AddStatsModifiers(new Dictionary<Stats, float>())
                    .AddStartPointPosition(at)
                    .AddViewPrefab(config.View)
                    .AddBaseAbilities(config.BaseAbilities)
                ;
        }
    }
}
