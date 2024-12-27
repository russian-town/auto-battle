using Entitas;

namespace Code.Gameplay.Features.Lifetime
{
    [Game] public class CurrentHealth : IComponent { public float Value; }
    [Game] public class MaxHealth : IComponent { public float Value; }        
    [Game] public class Dead : IComponent { }
    [Game] public class ProcessingDeath : IComponent { }
}
