using Code.Gameplay.Features.Motions.Configs;

namespace Code.Gameplay.Features.Motions.Factory
{
    public interface IMotionsFactory
    {
        GameEntity CreateMotion(MotionConfig config, int animatorId, int producerId, int targetId);
    }
}
