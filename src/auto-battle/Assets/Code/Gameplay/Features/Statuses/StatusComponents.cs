using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Gameplay.Features.Statuses
{
    [Game] public class Status : IComponent { }
    
    [Game] public class Lifetime : IComponent { public int Value; }
    [Game] public class ApplierStatusLink : IComponent { [EntityIndex] public int Value; }
    
    [Game] public class Applied : IComponent { }
    [Game] public class Unapplied : IComponent { }
    [Game] public class Affected : IComponent { }
    
    [Game] public class StatusTypeIdComponent : IComponent { public StatusTypeId Value; }
}
