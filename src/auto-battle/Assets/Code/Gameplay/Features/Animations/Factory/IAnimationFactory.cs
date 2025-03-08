using Code.Gameplay.Features.Animations.Configs;

namespace Code.Gameplay.Features.Animations.Factory
{
    public interface IAnimationFactory
    {
        GameEntity CreateAnimation(AnimationSetup setup, int producerId, int targetId);
    }
}
