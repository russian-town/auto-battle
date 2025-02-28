using UnityEngine;

namespace Code.Gameplay.Levels
{
    public class LevelDataProvider : ILevelDataProvider
    {
        public Transform UIRoot { get; private set; }
        public Transform HeroStartPoint { get; private set; }
        public Transform EnemyStartPoint { get; private set; }
        public Transform HeroHealthBarPoint { get; private set; }
        public Transform EnemyHealthBarPoint { get; private set; }
        
        public void SetUIRoot(Transform uiRoot) => UIRoot = uiRoot;
        public void SetHeroStartPoint(Transform heroStartPoint) => HeroStartPoint = heroStartPoint;
        public void SetEnemyStartPoint(Transform enemyStartPoint) => EnemyStartPoint = enemyStartPoint;
        public void SetHeroHealthBarPoint(Transform heroHealthBarPoint) => HeroHealthBarPoint = heroHealthBarPoint;
        public void SetEnemyHealthBarPoint(Transform enemyHealthBarPoint) => EnemyHealthBarPoint = enemyHealthBarPoint;
    }
}
