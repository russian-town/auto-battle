using System.Collections.Generic;
using Code.Gameplay.Features.AnimationEvents.Configs;
using Entitas;

namespace Code.Gameplay.Features.Animations
{
    [Game] public class Animation : IComponent { }
    [Game] public class AnimationHash : IComponent { public int Value; }
    [Game] public class AnimationSpeed : IComponent { public float Value; }
    [Game] public class CurrentFrame : IComponent { public float Value; }
    [Game] public class LastFrame : IComponent { public float Value; }
    [Game] public class NormalizeTime : IComponent { public float Value; }
    [Game] public class AnimationEventConfigs : IComponent { public List<AnimationEventConfig> Value; }
    [Game] public class Completed : IComponent { }
}
