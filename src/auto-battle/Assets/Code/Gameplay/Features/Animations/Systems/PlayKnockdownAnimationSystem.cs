using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class PlayKnockdownAnimationSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _animations;
        private readonly IGroup<GameEntity> _animators;

        public PlayKnockdownAnimationSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.AnimationSpeed,
                    GameMatcher.Knockdown,
                    GameMatcher.ProducerId,
                    GameMatcher.MovementSpeed,
                    GameMatcher.NormalizeTime
                ));
            
            _animators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.FighterAnimator,
                    GameMatcher.Id,
                    GameMatcher.WorldPosition,
                    GameMatcher.CurrentPosition,
                    GameMatcher.StartPointPosition,
                    GameMatcher.Step
                ));
        }

        public void Execute()
        {
            foreach (var animation in _animations)
            foreach (var animator in _animators)
            {
                if (animation.ProducerId != animator.Id)
                    continue;

                if (animation.ProducerId == animator.Id)
                    animator.FighterAnimator.Play(animation.AnimationHash, animation.NormalizeTime);
                
                if (animator.Step < 1f)
                {
                    animator.ReplaceStep(GetClampedStep(animator, animation));
                    animator.ReplaceWorldPosition(GetLerpPosition(animator));
                }
                else
                {
                    animator.ReplaceStep(0);
                    animator.ReplaceCurrentPosition(animator.WorldPosition);
                    animation.isCompleted = true;
                }

                if (animation.NormalizeTime >= 1f)
                    continue;
                
                animation.ReplaceNormalizeTime(GetClampedNormalizeTime(animation));
            }
        }

        private float GetClampedNormalizeTime(GameEntity animation) =>
            Mathf.Clamp01(animation.NormalizeTime + _time.DeltaTime * animation.AnimationSpeed);

        private static Vector3 GetLerpPosition(GameEntity animator) =>
            Vector3.Lerp(animator.CurrentPosition, animator.StartPointPosition, animator.Step);

        private float GetClampedStep(GameEntity animator, GameEntity animation) =>
            animator.Step + _time.DeltaTime * animation.MovementSpeed;
    }
}
