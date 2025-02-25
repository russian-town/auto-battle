using Code.Gameplay.Features.Animations.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Factory
{
    public interface IAnimationEventFactory
    {
        GameEntity CreateAnimation(EventSetup eventSetup, int producerId, int targetId, AnimationClip clip = null);
    }
}
