using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Fighter.Factory;
using Code.Gameplay.Levels;
using Entitas;

namespace Code.Gameplay.Features.Fight.Systems
{
    public class InitializeFightSystem : IInitializeSystem
    {
        private readonly IFighterFactory _fighterFactory;
        private readonly IAbilityFactory _abilityFactory;
        private readonly ILevelDataProvider _levelDataProvider;

        public InitializeFightSystem(
            IFighterFactory fighterFactory,
            IAbilityFactory abilityFactory,
            ILevelDataProvider levelDataProvider)
        {
            _fighterFactory = fighterFactory;
            _abilityFactory = abilityFactory;
            _levelDataProvider = levelDataProvider;
        }

        public void Initialize()
        {
            var hero = _fighterFactory.CreateFighter(
                _levelDataProvider.HeroStartPoint, _levelDataProvider.HeroStartRotation);
            var enemy = _fighterFactory.CreateFighter(
                _levelDataProvider.EnemyStartPoint, _levelDataProvider.EnemyStartRotation);

            hero.AddTargetId(enemy.Id);
            enemy.AddTargetId(hero.Id);

            _abilityFactory.CreateAbility(AbilityTypeId.DefaultAttack, hero.Id, enemy.Id);
        }
    }
}
