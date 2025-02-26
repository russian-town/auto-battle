using Code.Common.Entity;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Fighter.Factory;
using Code.Gameplay.Levels;
using Entitas;

namespace Code.Gameplay.Features.Fighter.Systems
{
    public class InitializeFighterSystem : IInitializeSystem
    {
        private readonly IFighterFactory _fighterFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IAbilityFactory _abilityFactory;

        public InitializeFighterSystem(
            IFighterFactory fighterFactory,
            ILevelDataProvider levelDataProvider,
            IAbilityFactory abilityFactory)
        {
            _fighterFactory = fighterFactory;
            _levelDataProvider = levelDataProvider;
            _abilityFactory = abilityFactory;
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

            hero.AddTargetId(enemy.Id);
            enemy.AddTargetId(hero.Id);

            _abilityFactory.CreateAbility(AbilityTypeId.DefaultAttack, hero.Id, enemy.Id);
            //_abilityFactory.CreateAbility(AbilityTypeId.Counterattack, enemy.Id, hero.Id);
        }
    }
}
