using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Configs;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using AnimationEvent = Code.Gameplay.Features.Animations.Configs.AnimationEvent;

namespace Code.Gameplay.Features.Animations
{
    [Game] public class HashCode : IComponent { public int Value; }
    [Game] public class AllFrames : IComponent { public float Value; }
    [Game] public class DurationTime : IComponent { public float Value; }
    [Game] public class TransitionTime : IComponent { public float Value; }
    [Game] public class CurrentFrame : IComponent { public float Value; }
    [Game] public class TargetFrame : IComponent { public float Value; }
    [Game] public class AnimationEvents : IComponent { public List<AnimationEvent> Value; }
    [Game] public class AnimationLinkedId : IComponent { [EntityIndex] public int Value; }
    [Game] public class Animation : IComponent { }
    [Game] public class AnimationQueue : IComponent { public Queue<AnimationSetup> Value; }
    [Game] public class Started : IComponent { }
    [Game] public class AnimationEventsCreated : IComponent { }
    [Game] public class Completed : IComponent { }
    [Game] public class Interrupted : IComponent { }
    [Game] public class AnimationEventComponent : IComponent { }
    [Game] public class Invoked : IComponent { }
}
