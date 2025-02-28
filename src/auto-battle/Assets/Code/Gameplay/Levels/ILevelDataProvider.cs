using UnityEngine;

namespace Code.Gameplay.Levels
{
    public interface ILevelDataProvider
    {
        public Transform UIRoot { get; }
        public Transform HeroStartPoint { get; }
        public Transform EnemyStartPoint { get; }
        public Transform HeroHealthBarPoint { get; }
        public Transform EnemyHealthBarPoint { get; }
        
        public void SetUIRoot(Transform uiRoot);
        public void SetHeroStartPoint(Transform heroStartPoint);
        public void SetEnemyStartPoint(Transform enemyStartPoint);
        public void SetHeroHealthBarPoint(Transform heroHealthBarPoint);
        public void SetEnemyHealthBarPoint(Transform enemyHealthBarPoint);
    }
}
