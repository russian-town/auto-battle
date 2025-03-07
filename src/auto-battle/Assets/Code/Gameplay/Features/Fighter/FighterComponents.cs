using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Fighter.Behaviours;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Fighter
{
    [Game] public class FighterComponent : IComponent { }
    [Game] public class FighterAnimatorComponent : IComponent { public FighterAnimator Value; }
    [Game] public class Damage : IComponent { public float Value; }
    [Game] public class StartPointPosition : IComponent { public Vector3 Value; }
    [Game] public class BaseAbilities : IComponent { public List<AbilityConfig> Value; }
    [Game] public class Mana : IComponent { public int Value; }
    [Game] public class Offensive : IComponent { }
    [Game] public class Defence : IComponent { }
}