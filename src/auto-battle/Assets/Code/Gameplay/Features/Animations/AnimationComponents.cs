using Entitas;

namespace Code.Gameplay.Features.Animations
{
    [Game] public class HashCode : IComponent { public int Value; }
    [Game] public class NormalizedTime : IComponent { public float Value; }
    [Game] public class EventFrame : IComponent { public float Value; }
    [Game] public class CurrentFrame : IComponent { public float Value; }
    [Game] public class MaxFrame : IComponent { public float Value; }
    [Game] public class Invoke : IComponent { }
    [Game] public class Completed : IComponent { }
}
