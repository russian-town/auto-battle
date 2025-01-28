using Code.Gameplay.Features.Statuses.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Statuses
{
    public class StatusFeature : Feature
    {
        public StatusFeature(ISystemFactory systems)
        {
            Add(systems.Create<RemoveTargetAbilityByCounterattackStatusSystem>());
            Add(systems.Create<RemoveTargetAnimationByCounterattackStatusSystem>());
            Add(systems.Create<ApplyDamageAbsorptionStatusSystem>());
            
            Add(systems.Create<CleanupUnappliedStatusLinkedChangesSystem>());
            Add(systems.Create<CleanupUnappliedStatusesSystem>());
        }
    }
}
