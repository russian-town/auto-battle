using Code.Gameplay.Levels;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        public Transform HeroStartPoint;
        public Transform EnemyStartPoint;
        
        private ILevelDataProvider _levelDataProvider;

        [Inject]
        public void Construct(ILevelDataProvider levelDataProvider) =>
            _levelDataProvider = levelDataProvider;

        public void Initialize()
        {
         _levelDataProvider.SetStartPoints(
             HeroStartPoint.position,
             EnemyStartPoint.position);
         
         _levelDataProvider.SetStartRotation(
             HeroStartPoint.rotation,
             EnemyStartPoint.rotation);
        }
    }
}
