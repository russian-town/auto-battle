using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Fighter.Factory;
using Code.Gameplay.Levels;
using Entitas;
using UnityEngine;

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
            var hero = _fighterFactory.CreateFighter(
                GetTransformByPositionTypeIdFor(FighterTypeId.Hero).position,
                GetTransformByPositionTypeIdFor(FighterTypeId.Hero).rotation,
                FighterTypeId.Hero);

            var enemy = _fighterFactory.CreateFighter(
                GetTransformByPositionTypeIdFor(FighterTypeId.Enemy).position,
                GetTransformByPositionTypeIdFor(FighterTypeId.Enemy).rotation,
                FighterTypeId.Enemy);

            _abilityFactory.CreateAbility(AbilityTypeId.DoubleStrike, hero.Id, enemy.Id);
        }

        private Transform GetTransformByPositionTypeIdFor(FighterTypeId typeId) =>
            _levelDataProvider.GetTransformByPositionTypeIdFor(typeId, PositionTypeId.StartPoint);
    }
}
