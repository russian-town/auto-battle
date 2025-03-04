using System.Collections.Generic;
using Code.Gameplay.Features.Animations;
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
    [Game] public class CurrentAnimationIndex : IComponent { public int Value; }
    [Game] public class LastAnimationIndex : IComponent { public int Value; }
    [Game] public class ManaCost : IComponent { public int Value; }

    [Game] public class StatusSetups : IComponent { public List<StatusSetup> Value; }
    [Game] public class EffectSetups : IComponent { public List<EffectSetup> Value; }
    [Game] public class AnimationSetups : IComponent { public List<AnimationSetup> Value; }
    
    [Game] public class DefaultAttackAbility : IComponent { }
    [Game] public class BlockAbility : IComponent { }
    [Game] public class CounterattackAbility : IComponent { }
    [Game] public class DoubleStrikeAbility : IComponent { }
    [Game] public class DodgeAbility : IComponent { }
}
