using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Animations.Configs;
using Code.Gameplay.Features.Effect.Configs;
using Code.Gameplay.Features.Statuses.Configs;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Gameplay.Features.Abilities
{
    [Game] public class Ability : IComponent { }
    [Game] public class AbilityTypeIdComponent : IComponent { public AbilityTypeId Value; }
    [Game] public class ParentAbilityId : IComponent { [EntityIndex] public int Value; }
    [Game] public class ManaCost : IComponent { public int Value; }
    
    [Game] public class Offensive : IComponent { }
    [Game] public class Defence : IComponent { }

    [Game] public class StatusSetups : IComponent { public List<StatusSetup> Value; }
    [Game] public class EffectSetups : IComponent { public List<EffectSetup> Value; }
    [Game] public class AnimationSetups : IComponent { public List<AnimationSetup> Value; }
    [Game] public class Stages : IComponent { public List<Stage> Value; }
    
    [Game] public class DefaultAttack : IComponent { }
    [Game] public class Block : IComponent { }
    [Game] public class Counterattack : IComponent { }
    [Game] public class DoubleStrike : IComponent { }
    [Game] public class Dodge : IComponent { }
}
