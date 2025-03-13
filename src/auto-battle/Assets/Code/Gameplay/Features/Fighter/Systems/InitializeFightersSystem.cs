﻿using Code.Common.Extensions;
using Code.Gameplay.Features.Fighter.Factory;
using Code.Gameplay.Features.HealthBar.Factory;
using Code.Gameplay.Levels;
using Entitas;

namespace Code.Gameplay.Features.Fighter.Systems
{
    public class InitializeFightersSystem : IInitializeSystem
    {
        private readonly IFighterFactory _fighterFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IHealthBarFactory _healthBarFactory;

        public InitializeFightersSystem(
            IFighterFactory fighterFactory,
            ILevelDataProvider levelDataProvider,
            IHealthBarFactory healthBarFactory)
        {
            _fighterFactory = fighterFactory;
            _levelDataProvider = levelDataProvider;
            _healthBarFactory = healthBarFactory;
        }

        public void Initialize()
        {
            var heroStartPosition = _levelDataProvider.HeroStartPoint.position;
            var heroStartRotation = _levelDataProvider.HeroStartPoint.rotation;

            var hero = _fighterFactory
                .CreateFighter(heroStartPosition, heroStartRotation, FighterTypeId.Hero);

            var enemyStartPosition = _levelDataProvider.EnemyStartPoint.position;
            var enemyStartRotation = _levelDataProvider.EnemyStartPoint.rotation;

            var enemy = _fighterFactory
                .CreateFighter(enemyStartPosition, enemyStartRotation, FighterTypeId.Enemy);

            hero.AddTargetId(enemy.Id)
                .With(x => x.isReadyToNextTurn = true);
            
            enemy.AddTargetId(hero.Id)
                 .With(x => x.isReadyToNextTurn = true);
            
            _healthBarFactory.CreateHealthBar(hero.Id, _levelDataProvider.HeroHealthBarPoint.position, _levelDataProvider.UIRoot);
            _healthBarFactory.CreateHealthBar(enemy.Id, _levelDataProvider.EnemyHealthBarPoint.position, _levelDataProvider.UIRoot);

            hero.ReplaceMana(1);
        }
    }
}
