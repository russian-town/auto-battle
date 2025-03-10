﻿using System.Collections.Generic;
using Code.Gameplay.Features.AnimationEvents.Configs;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Gameplay.Features.Animations
{
    [Game] public class Animation : IComponent { }
    [Game] public class AnimationHash : IComponent { public int Value; }
    [Game] public class AnimatorId : IComponent { public int Value; }
    [Game] public class CurrentFrame : IComponent { public float Value; }
    [Game] public class LastFrame : IComponent { public float Value; }
    [Game] public class AnimationLinkedId : IComponent { [EntityIndex] public int Value; }
    [Game] public class AnimationEventSetups : IComponent { public List<AnimationEventSetup> Value; }
    [Game] public class Completed : IComponent { }
}
