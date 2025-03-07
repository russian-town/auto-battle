using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Configs;
using Code.Gameplay.Features.Motions.Configs;
using Entitas;

namespace Code.Gameplay.Features.Motions
{
    [Game] public class Motion : IComponent { }
    [Game] public class MotionQueue : IComponent { public Queue<MotionConfig> Value; }
    [Game] public class MoveNext : IComponent { }
    [Game] public class MotionQueueLinkedId : IComponent { public int Value; }
    [Game] public class Progress : IComponent { public float Value; }
    [Game] public class ProgressFilled : IComponent { }
    [Game] public class Empty : IComponent { }
    
    [Game] public class AnimationSetupComponent : IComponent { public AnimationSetup Value; }
    [Game] public class MotionConfigs : IComponent { public List<MotionConfig> Value; }
}
