using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systems)
        {
            Add(systems.Create<SetContainerForChildEntitiesSystem>());
            
            Add(systems.Create<UpdatePositionByEntitiesSystem>());
            Add(systems.Create<UpdateRotationByEntitiesSystem>());
            
            Add(systems.Create<IncreaseProgressByMovements>());
            Add(systems.Create<MoveEntitiesToTargetPositionSystem>());
            Add(systems.Create<GetNextPointByReachedMovementsSystem>());
            Add(systems.Create<CreateAnimationByActiveMovementsSystem>());
            
            Add(systems.Create<CleanupProcessedMovementsSystem>());
        }
    }
}
