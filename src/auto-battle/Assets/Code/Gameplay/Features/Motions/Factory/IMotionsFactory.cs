using System.Collections.Generic;
using Code.Gameplay.Features.Motions.Configs;

namespace Code.Gameplay.Features.Motions.Factory
{
    public interface IMotionsFactory
    {
        GameEntity CreateMotionQueue(IEnumerable<MotionConfig> motions, int animatorId, int producerId, int targetId);
    }
}
