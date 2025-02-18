using Entitas;

namespace Code.Gameplay.Features.AnimationEvents
{
    [Game] public class AnimationEvent : IComponent { }
    [Game] public class TimeLeft : IComponent { public float Value; }
    [Game] public class Invoked : IComponent { }
}
