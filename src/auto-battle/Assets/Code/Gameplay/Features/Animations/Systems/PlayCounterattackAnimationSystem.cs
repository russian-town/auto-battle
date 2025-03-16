using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class PlayCounterattackAnimationSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _animations;
        private readonly IGroup<GameEntity> _animators;

        public PlayCounterattackAnimationSystem(GameContext game, ITimeService time)
        {
            _time = time;
            
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.Counterattack,
                    GameMatcher.AnimationHash,
                    GameMatcher.NormalizeTime,
                    GameMatcher.AnimationSpeed,
                    GameMatcher.CooldownUp
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
