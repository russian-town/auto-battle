using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.Gameplay.Common
{
    public class CommonComponents
    {
        [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
        [Game] public class WorldPosition : IComponent { public Vector3 Value; }
        [Game] public class WorldRotation : IComponent { public Quaternion Value; }
        [Game] public class TransformComponent : IComponent { public Transform Value; }
    }
}
