using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class PlayDodgeAnimationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _dodgeAnimations;
        private readonly IGroup<GameEntity> _defaultAttackAnimations;
        private readonly IGroup<GameEntity> _animators;

        public PlayDodgeAnimationSystem(GameContext game)
        {
            _dodgeAnimations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.Dodge,
                    GameMatcher.AnimationHash,
                    GameMatcher.ProducerId,
                    GameMatcher.NormalizeTime
                ));
            
            _defaultAttackAnimations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.DefaultAttack,
                    GameMatcher.TargetId,
                    GameMatcher.NormalizeTime
                ));
            
            _animators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.FighterAnimator,
                    GameMatcher.Id
                ));
        }

        public void Execute()
        {
            foreach (var defaultAttackAnimation in _defaultAttackAnimations)
            foreach (var dodgeAnimation in _dodgeAnimations)
            foreach (var animator in _animators)
            {
                if (dodgeAnimation.ProducerId == defaultAttackAnimation.TargetId)
                    dodgeAnimation.ReplaceNormalizeTime(defaultAttackAnimation.NormalizeTime);

                if (dodgeAnimation.ProducerId == animator.Id)
                    animator.FighterAnimator.Play(dodgeAnimation.AnimationHash, dodgeAnimation.NormalizeTime);
                
                if (defaultAttackAnimation.NormalizeTime >= 1f)
                    dodgeAnimation.isCompleted = true;
            }
        }
    }
}
