using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Levels;
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

            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .With(x => x.isFighter = true)
                    .AddWorldPosition(at)
                    .AddWorldRotation(rotation)
                    .AddDirection(Vector3.zero)
                    .AddSpeed(config.Speed)
                    .AddDamage(statByType[Stats.Damage])
                    .AddAttackPower(statByType[Stats.AttackPower])
                    .AddCurrentHealth(statByType[Stats.MaxHealth])
                    .AddMaxHealth(statByType[Stats.MaxHealth])
                    .AddBaseStats(statByType)
                    .AddStatsModifiers(new Dictionary<Stats, float>())
                    .AddFighterTypeId(fighterTypeId)
                    .AddStartPointPosition(at)
                    .AddViewPrefab(config.View)
                    .AddBaseAbilities(config.BaseAbilities)
                ;
        }
    }
}
