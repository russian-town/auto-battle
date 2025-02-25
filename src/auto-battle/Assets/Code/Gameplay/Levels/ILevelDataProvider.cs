using Code.Gameplay.Features.Fighter;
using UnityEngine;

namespace Code.Gameplay.Levels
{
    public interface ILevelDataProvider
    {
        public Transform UIRoot { get; }
        public Transform HeroStartPoint { get; }
        public Transform EnemyStartPoint { get; }
        public void SetUIRoot(Transform uiRoot);
        public void SetHeroStartPoint(Transform heroStartPoint);
        public void SetEnemyStartPoint(Transform enemyStartPoint);
    }
}
