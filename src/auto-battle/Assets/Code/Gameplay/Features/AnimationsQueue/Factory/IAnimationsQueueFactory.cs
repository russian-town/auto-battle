using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Configs;

namespace Code.Gameplay.Features.AnimationsQueue.Factory
{
    public interface IAnimationsQueueFactory
    {
        GameEntity CreateAnimationQueue(IEnumerable<AnimationSetup> animationSetups, int producerId, int targetId, int parentAbilityId);
    }
}
