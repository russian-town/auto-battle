using Code.Gameplay.Features.AnimationEvents.Configs;

namespace Code.Gameplay.Features.AnimationEvents.Factory
{
    public interface IAnimationEventFactory
    {
        GameEntity CreateAnimationEvent(AnimationEventConfig config, int animationLinkedId, int producerId, int targetId);
    }
}
