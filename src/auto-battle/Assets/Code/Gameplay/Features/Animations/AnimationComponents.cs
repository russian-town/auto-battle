﻿using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Configs;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Gameplay.Features.Animations
{
    [Game] public class Animation : IComponent { }
    [Game] public class AnimationTypeIdComponent : IComponent { public AnimationTypeId Value; }
    [Game] public class AnimationTime : IComponent { public float Value; }
    [Game] public class AnimationCurrentTime : IComponent { public float Value; }

    [Game] public class EventSetups : IComponent { public List<EventSetup> Value; }
    [Game] public class TargetDistance : IComponent { public float Value; }
    [Game] public class AnimationStarted : IComponent { }
    [Game] public class AnimationEnded : IComponent { }
    
    [Game] public class EventComponent : IComponent { }
    [Game] public class ParentAnimationId : IComponent { [EntityIndex] public int Value; }

    [Game] public class CaptureOnTimeline : IComponent { public float Value; }
    [Game] public class Invoked : IComponent { }
    
    [Game] public class DefaultAttackAnimation : IComponent { }
    [Game] public class DoubleStrikeAnimation : IComponent { }
    [Game] public class DodgeAnimation : IComponent { }
    [Game] public class HitAnimation : IComponent { }
    [Game] public class BlockAnimation : IComponent { }
    [Game] public class CounterattackAnimation : IComponent { }
    [Game] public class FallAnimation : IComponent { }
    [Game] public class MoveToTargetAnimation : IComponent { }
    [Game] public class MoveToStartPointAnimation : IComponent { }
}
