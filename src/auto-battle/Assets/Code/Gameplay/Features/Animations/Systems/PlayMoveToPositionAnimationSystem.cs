using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class PlayMoveToPositionAnimationSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _animations;
        private readonly IGroup<GameEntity> _animators;

        public PlayMoveToPositionAnimationSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.MoveToPosition,
                    GameMatcher.AnimationHash,
                    GameMatcher.AnimationSpeed,
                    GameMatcher.MovementSpeed,
                    GameMatcher.ProducerId
                    ));
            
            _animators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.FighterAnimator,
                    GameMatcher.Id,
                    GameMatcher.WorldPosition,
                    GameMatcher.CurrentPosition,
                    GameMatcher.TargetPosition,
                    GameMatcher.StartPointPosition,
                    GameMatcher.Step
                    ));
        }

        public void Execute()
        {
            foreach (var animation in _animations)
            foreach (var animator in _animators)
            {
                if(animation.ProducerId != animator.Id)
                    continue;

                animator.ReplaceStep(GetClampedStep(animation, animator));
                animator.ReplaceWorldPosition(GetLerpPosition(animator));

                if (animator.Step >= 1)
                {
                    animation.isCompleted = true;
                    animator.ReplaceCurrentPosition(animator.WorldPosition);
                    animator.ReplaceStep(0);
                    continue;
                }

                if (animation.ProducerId == animator.Id)
                    animator.FighterAnimator.Play(animation.AnimationHash, Mathf.Repeat(_time.Time, 1f));
            }
        }

        private static Vector3 GetLerpPosition(GameEntity animator) =>
            Vector3.Lerp(animator.StartPointPosition, animator.TargetPosition - new Vector3(2f, 0f, 0f), animator.Step);

        private float GetClampedStep(GameEntity animation, GameEntity animator) =>
            Mathf.Clamp01(animator.Step + _time.DeltaTime * animation.MovementSpeed);
    }
}
