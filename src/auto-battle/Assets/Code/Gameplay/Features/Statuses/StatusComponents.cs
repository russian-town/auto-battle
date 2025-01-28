using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Gameplay.Features.Statuses
{
    [Game] public class Status : IComponent { }
    [Game] public class DamageAbsorption : IComponent { }
    
    [Game] public class BlockStatus : IComponent { }
    [Game] public class DodgeStatus : IComponent { }
    [Game] public class StunStatus : IComponent { }
    [Game] public class PoisonStatus : IComponent { }
    [Game] public class CounterattackStatus : IComponent { }
    
    [Game] public class ApplierStatusLink : IComponent { [EntityIndex] public int Value; }
    
    [Game] public class Applied : IComponent { }
    [Game] public class Unapplied : IComponent { }
    [Game] public class Affected : IComponent { }
}
