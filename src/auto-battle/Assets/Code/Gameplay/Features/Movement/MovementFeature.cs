using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateTransformPositionSystem>());
            Add(systems.Create<UpdateAnchoredPositionSystem>());
            
            Add(systems.Create<MoveProducerForDistanceAbilitySystem>());
            Add(systems.Create<DirectionDeltaMoveSystem>());
            
            Add(systems.Create<AnimateFighterMovementSystem>());
        }
    }
}
