using Code.Gameplay.Features.Motions.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Motions
{
    public class MotionFeature : Feature
    {
        public MotionFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkEmptyMotionQueueSystem>());
            
            Add(systems.Create<GetNextMotionConfigSystem>());
            
            Add(systems.Create<CreateAnimationByMotionsSystem>());
            Add(systems.Create<CreateMovementByMotionsSystem>());
            
            Add(systems.Create<UpdateProgressByMotionSystem>());
            Add(systems.Create<MarkMoveNextMotionQueueSystem>());
            
            Add(systems.Create<CleanupFilledMotionsSystem>());
        }
    }
}
