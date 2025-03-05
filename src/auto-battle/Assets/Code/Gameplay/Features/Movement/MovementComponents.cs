using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
    [Game] public class HasContainer : IComponent { }
    [Game] public class Movement : IComponent { }
    [Game] public class TargetPositions : IComponent { public Queue<Vector3> Value; }
    [Game] public class TargetPosition : IComponent { public Vector3 Value; }
    [Game] public class Speed : IComponent { public float Value; }
    [Game] public class Progress : IComponent { public float Value; }
    [Game] public class Reached : IComponent { }
}
