using Code.Gameplay.Features.Rotation.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Rotation
{
    public class RotationFeature : Feature
    {
        public RotationFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateTransformRotationSystem>());
        }
    }
}
