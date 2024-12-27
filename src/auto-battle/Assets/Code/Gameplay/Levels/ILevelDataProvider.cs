using UnityEngine;

namespace Code.Gameplay.Levels
{
    public interface ILevelDataProvider
    {
        Vector3 HeroStartPoint { get; }
        Vector3 EnemyStartPoint { get; }
        Quaternion HeroStartRotation { get; }
        Quaternion EnemyStartRotation { get; }
        void SetStartPoints(Vector3 heroStartPoint, Vector3 enemyStartPoint);
        void SetStartRotation(Quaternion heroStartRotation, Quaternion enemyStartRotation);
    }
}
