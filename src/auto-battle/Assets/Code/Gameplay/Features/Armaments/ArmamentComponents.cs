using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Configs;
using Entitas;

namespace Code.Gameplay.Features.Armaments
{
    [Game] public class Armament : IComponent { }
    [Game] public class EffectSetups : IComponent { public List<EffectSetup> Value; }
}
