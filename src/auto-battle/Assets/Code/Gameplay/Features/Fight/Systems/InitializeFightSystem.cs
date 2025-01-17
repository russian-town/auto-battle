using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Damage.Factory;
using Code.Gameplay.Features.Fight.Factory;
using Code.Gameplay.Features.Fighter;
using Code.Gameplay.Features.Fighter.Factory;
using Code.Gameplay.Levels;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Fight.Systems
{
    public class InitializeFightSystem : IInitializeSystem
    {
        private readonly IFighterFactory _fighterFactory;
        private readonly IAbilityFactory _abilityFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IHealthBarFactory _healthBarFactory;
        private readonly IFightFactory _fightFactory;

        public InitializeFightSystem(
            IFighterFactory fighterFactory,
            IAbilityFactory abilityFactory,
            ILevelDataProvider levelDataProvider,
            IHealthBarFactory healthBarFactory,
            IFightFactory fightFactory)
        {
            _fighterFactory = fighterFactory;
            _abilityFactory = abilityFactory;
            _levelDataProvider = levelDataProvider;
            _healthBarFactory = healthBarFactory;
            _fightFactory = fightFactory;
        }

        public void Initialize()
        {
            var heroStartPoint = GetTransform(FighterTypeId.Hero, PositionTypeId.StartPoint);
            var enemyStartPoint = GetTransform(FighterTypeId.Enemy, PositionTypeId.StartPoint);
            
            var hero = _fighterFactory.CreateFighter(
                heroStartPoint.position,
                heroStartPoint.rotation,
                FighterTypeId.Hero);
            
            var enemy = _fighterFactory.CreateFighter(
                enemyStartPoint.position,
                enemyStartPoint.rotation,
                FighterTypeId.Enemy);

            hero.AddTargetId(enemy.Id)
                .With(x => x.isOffensive = true);
            enemy.AddTargetId(hero.Id)
                .With(x => x.isDefense = true);

            _healthBarFactory.CreateHealthBar(
                hero.Id,
                GetTransform(FighterTypeId.Hero, PositionTypeId.HealthBar));

            _healthBarFactory.CreateHealthBar(
                enemy.Id,
                GetTransform(FighterTypeId.Enemy, PositionTypeId.HealthBar));

            var ability = _abilityFactory.CreateAbility(AbilityTypeId.DefaultAttack, hero.Id, enemy.Id);
            _fightFactory.CreateFight(ability.Cooldown, enemy.Id, hero.Id);
        }

        private Transform GetTransform(FighterTypeId fighterTypeId, PositionTypeId positionTypeId) =>
            _levelDataProvider.GetTransformByPositionTypeIdFor(
                fighterTypeId,
                positionTypeId);
    }
}
