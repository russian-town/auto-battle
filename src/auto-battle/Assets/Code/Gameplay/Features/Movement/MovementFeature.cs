using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateTransformPositionSystem>());
            Add(systems.Create<UpdateAnchoredPositionSystem>());
            
            Add(systems.Create<DirectionDeltaMoveSystem>());
            
            //Add(systems.Create<AnimateFighterMovementSystem>());
        }
    }
}
