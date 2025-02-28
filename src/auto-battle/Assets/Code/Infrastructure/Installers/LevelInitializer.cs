using Code.Gameplay.Levels;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        [SerializeField] private Transform _heroStartPoint;
        [SerializeField] private Transform _enemyStartPoint;
        
        private ILevelDataProvider _levelDataProvider;

        [Inject]
        public void Construct(ILevelDataProvider levelDataProvider) =>
            _levelDataProvider = levelDataProvider;

        public void Initialize()
        {
            _levelDataProvider.SetHeroStartPoint(_heroStartPoint);
            _levelDataProvider.SetEnemyStartPoint(_enemyStartPoint);
        }
    }
}
