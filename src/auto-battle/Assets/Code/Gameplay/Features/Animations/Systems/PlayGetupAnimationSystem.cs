using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class PlayGetupAnimationSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _animations;
        private readonly IGroup<GameEntity> _animators;

        public PlayGetupAnimationSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.Getup,
                    GameMatcher.ProducerId,
                    GameMatcher.AnimationHash,
                    GameMatcher.NormalizeTime,
                    GameMatcher.AnimationSpeed
                ));
            
            _animators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.FighterAnimator
                ));
        }

        public void Execute()
        {
            foreach (var animation in _animations)
            foreach (var animator in _animators)
            {
                animation.ReplaceNormalizeTime(GetClampedNormalizeTime(animation));
                
                if (animation.ProducerId == animator.Id)
                    animator.FighterAnimator.Play(animation.AnimationHash, animation.NormalizeTime);

                if (animation.NormalizeTime >= 1f)
                    animation.isCompleted = true;
            }
        }

        private float GetClampedNormalizeTime(GameEntity animation) =>
            Mathf.Clamp01(animation.NormalizeTime + _time.DeltaTime * animation.AnimationSpeed);
    }
}
