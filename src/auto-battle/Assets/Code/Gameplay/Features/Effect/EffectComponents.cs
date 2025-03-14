﻿using Code.Gameplay.Features.Animations.Configs;
using Code.Gameplay.Features.Effect.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Effect
{
    [Game] public class ProducerId : IComponent { public int Value; }
    [Game] public class TargetId : IComponent { public int Value; }
    
    [Game] public class Effect : IComponent { }
    [Game] public class EffectValue : IComponent { public float Value; }
    [Game] public class AnimationSetupComponent : IComponent { public AnimationSetup Value; }
    [Game] public class EffectWindowComponent : IComponent { public EffectWindow Value; }
    
    [Game] public class DamageEffect : IComponent { }
    [Game] public class HealEffect : IComponent { }
    [Game] public class PushEffect : IComponent { }
    [Game] public class Processed : IComponent { }
}
