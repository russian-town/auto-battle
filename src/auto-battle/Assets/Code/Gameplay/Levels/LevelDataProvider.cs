using UnityEngine;

namespace Code.Gameplay.Levels
{
    public class LevelDataProvider : ILevelDataProvider
    {
        public Vector3 HeroStartPoint { get; private set; }
        public Vector3 EnemyStartPoint { get; private set; }
        
        public Quaternion HeroStartRotation { get; private set; }
        public Quaternion EnemyStartRotation { get; private set; }

        public void SetStartPoints(Vector3 heroStartPoint, Vector3 enemyStartPoint)
        {
            HeroStartPoint = heroStartPoint;
            EnemyStartPoint = enemyStartPoint;
        }

        public void SetStartRotation(Quaternion heroStartRotation, Quaternion enemyStartRotation)
        {
            HeroStartRotation = heroStartRotation;
            EnemyStartRotation = enemyStartRotation;
        }
    }
}
