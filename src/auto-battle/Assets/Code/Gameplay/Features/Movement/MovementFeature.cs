using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateTimeLeftByMovementsSystem>());
            
            Add(systems.Create<UpdatePositionByGraphSystem>());
            
            Add(systems.Create<UpdateTransformPositionSystem>());
            Add(systems.Create<UpdateAnchoredPositionSystem>());
        }
    }
}
