using System.Collections.Generic;
using Code.Gameplay.Features.Progress.Config;
using Entitas;

namespace Code.Gameplay.Features.Progress
{
    [Game] public class Speed : IComponent { public float Value; }
    [Game] public class ProgressQueue : IComponent { public Queue<ProgressSetup> Value; }
    [Game] public class ProgressFilled : IComponent { }
}
