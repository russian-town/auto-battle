using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class UpdatePercentByAnimationEventsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animationEvents;
        private readonly IGroup<GameEntity> _animated;
        private readonly List<GameEntity> _buffer = new(32);

        public UpdatePercentByAnimationEventsSystem(GameContext game)
        {
            _animationEvents = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.AnimationHash,
                        GameMatcher.AnimationPercent,
                        GameMatcher.AnimationPercentLeft,
                        GameMatcher.AnimationClip,
                        GameMatcher.ProducerId
                    )
                    .NoneOf(GameMatcher.Invoked));

            _animated = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Id,
                        GameMatcher.AnimatorClipInfo,
                        GameMatcher.AnimatorStateInfo
                    ));
        }

        public void Execute()
        {
            foreach (var animationEvent in _animationEvents.GetEntities(_buffer))
            foreach (var animated in _animated)
            {
                if (animationEvent.ProducerId != animated.Id)
                    continue;

                if (animationEvent.AnimationHash == animated.AnimatorClipInfo.clip.GetHashCode())
                    animationEvent.ReplaceAnimationPercentLeft(GetAnimationPercent(animated, animationEvent));

                if (animationEvent.AnimationPercentLeft > animationEvent.AnimationPercent)
                    animationEvent.isInvoked = true;
            }
        }

        private static float GetAnimationPercent(GameEntity animated, GameEntity animationEvent) =>
            animated.AnimatorStateInfo.normalizedTime
            * (animationEvent.AnimationClip.length
               * animationEvent.AnimationClip.frameRate);
    }
}
