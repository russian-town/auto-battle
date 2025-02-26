using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
    [Game] public class TimeLeft : IComponent { public float Value; }
    [Game] public class HorizontalGraph : IComponent { public AnimationCurve Value; }
    [Game] public class VerticalGraph : IComponent { public AnimationCurve Value; }
    [Game] public class SpeedGraph : IComponent { public AnimationCurve Value; }
    [Game] public class MoveForwardClip : IComponent { public AnimationClip Value; }
    [Game] public class MoveBackwardClip : IComponent { public AnimationClip Value; }
    [Game] public class Moving : IComponent { }
    [Game] public class Movement : IComponent { }
    [Game] public class Reached : IComponent { }
}
