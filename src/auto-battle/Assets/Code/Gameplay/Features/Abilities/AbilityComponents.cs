using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Configs;
using Code.Gameplay.Features.Statuses.Configs;
using Entitas;

namespace Code.Gameplay.Features.Abilities
{
    [Game] public class Active : IComponent { }
    [Game] public class StatusSetups : IComponent { public List<StatusSetup> Value; }
    [Game] public class EffectSetups : IComponent { public List<EffectSetup> Value; }
    [Game] public class Ability : IComponent { }
    [Game] public class Block : IComponent { }
    [Game] public class Counterattack : IComponent { }
    [Game] public class DoubleStrike : IComponent { }
    [Game] public class Dodge : IComponent { }
}
