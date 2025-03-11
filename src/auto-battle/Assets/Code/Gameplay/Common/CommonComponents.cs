using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.Gameplay.Common
{
    public class CommonComponents
    {
        [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
        [Game] public class Parent : IComponent { public Transform Value; }
        [Game] public class Name : IComponent { public string Value; }
        [Game] public class Active : IComponent { }
        [Game] public class WorldPosition : IComponent { public Vector3 Value; }
        [Game] public class AnchoredPositionComponent : IComponent { public Vector2 Value; }
        [Game] public class WorldRotation : IComponent { public Quaternion Value; }
        [Game] public class TransformComponent : IComponent { public Transform Value; }
        [Game] public class Container : IComponent { public Transform Value; }
    }
}
