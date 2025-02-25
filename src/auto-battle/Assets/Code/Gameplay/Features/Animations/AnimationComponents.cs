using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.Gameplay.Features.Animations
{
    [Game] public class AnimationHash : IComponent { [EntityIndex] public int Value; }
    [Game] public class AnimationPercent : IComponent { public float Value; }
    [Game] public class AnimationPercentLeft : IComponent { public float Value; }
    [Game] public class AnimationClipComponent : IComponent { public AnimationClip Value; }
    [Game] public class AnimatorClipInfoComponent : IComponent { public AnimatorClipInfo Value; }
    [Game] public class AnimatorStateInfoComponent : IComponent { public AnimatorStateInfo Value; }
    [Game] public class AnimationComplete : IComponent { }
    [Game] public class Invoked : IComponent { }
}
