using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
    [Game] public class HasContainer : IComponent { }
    [Game] public class Movement : IComponent { }
    [Game] public class TargetPosition : IComponent { public Vector3 Value; }
    
    [Game] public class MoveToTarget : IComponent { }
    [Game] public class MoveToStartPoint : IComponent { }
}
