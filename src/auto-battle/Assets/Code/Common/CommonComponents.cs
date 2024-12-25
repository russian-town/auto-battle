using Entitas;
using UnityEngine;

namespace Code.Common
{
    [Game] public class Destructed : IComponent { }
    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
}
