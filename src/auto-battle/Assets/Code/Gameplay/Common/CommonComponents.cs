using Entitas;
using Entitas.CodeGeneration.Attributes;
using TMPro;
using UnityEngine;

namespace Code.Gameplay.Common
{
    public class CommonComponents
    {
        [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
        [Game] public class Parent : IComponent { public Transform Value; }
        [Game] public class WorldPosition : IComponent { public Vector3 Value; }
        [Game] public class AnchoredPositionComponent : IComponent { public Vector2 Value; }
        [Game] public class WorldRotation : IComponent { public Quaternion Value; }
        [Game] public class TransformComponent : IComponent { public Transform Value; }
        [Game] public class RectTransformComponent : IComponent { public RectTransform Value; }
        [Game] public class HeroComponent : IComponent { }
        [Game] public class EnemyComponent : IComponent { }
    }
}
