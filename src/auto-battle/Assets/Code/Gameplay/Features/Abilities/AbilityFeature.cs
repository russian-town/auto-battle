using Code.Gameplay.Features.Abilities.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Abilities
{
    public class AbilityFeature : Feature
    {
        public AbilityFeature(ISystemFactory systems)
        {
            Add(systems.Create<DefaultAttackAbilitySystem>());
            Add(systems.Create<DoubleStrikeAbilitySystem>());
            Add(systems.Create<BlockAbilitySystem>());
            Add(systems.Create<DodgeAbilitySystem>());
            Add(systems.Create<CounterAttackAbilitySystem>());
            
            Add(systems.Create<DecreaseLifetimeByCompletedAbilitySystem>());
            
            Add(systems.Create<CleanupDeadAbilitySystem>());
        }
    }
}
