using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Configs;
using Entitas;

namespace Code.Gameplay.Features.AnimationsQueue
{
    [Game] public class QueueLinkedAnimationId : IComponent { public int Value; }
    [Game] public class AnimationsQueue : IComponent { public Queue<AnimationSetup> Value; }
    [Game] public class MoveNext : IComponent { }
    [Game] public class Empty : IComponent { }
}
