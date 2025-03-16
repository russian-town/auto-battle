using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
    [Game] public class HasContainer : IComponent { }
    [Game] public class MovementSpeed : IComponent { public float Value; }
    [Game] public class Step : IComponent { public float Value; }
    [Game] public class TargetPosition : IComponent { public Vector3 Value; }
    [Game] public class CurrentPosition : IComponent { public Vector3 Value; }
}
