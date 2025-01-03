using Code.Gameplay.Features.Fighter.Factory;
using Code.Gameplay.Features.Turn.Factory;
using Entitas;

namespace Code.Gameplay.Features.Fight.Systems
{
    public class InitializeFightSystem : IInitializeSystem
    {
        private readonly IFighterFactory _fighterFactory;
        private readonly ITurnFactory _turnFactory;

        public InitializeFightSystem(IFighterFactory fighterFactory, ITurnFactory turnFactory)
        {
            _fighterFactory = fighterFactory;
            _turnFactory = turnFactory;
        }

        public void Initialize()
        {
            var hero = _fighterFactory.CreateFighter();
            var enemy = _fighterFactory.CreateFighter();

            hero.AddTargetId(enemy.Id);
            enemy.AddTargetId(hero.Id);

            _turnFactory.CreateTurn(hero.Id);
        }
    }
}
