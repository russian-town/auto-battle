using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Fighter
{
    [Game] public class FighterComponent : IComponent { }
    [Game] public class Damage : IComponent { public float Value; }
    [Game] public class DistanceToTarget : IComponent { public float Value; }
    [Game] public class DistanceToStartPoint : IComponent { public float Value; }
    [Game] public class StartPointPosition : IComponent { public Vector3 Value; }
    [Game] public class Blocked : IComponent { }
}
