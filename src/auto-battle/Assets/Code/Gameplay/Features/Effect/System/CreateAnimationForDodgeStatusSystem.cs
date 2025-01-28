using Code.Gameplay.Features.Animations;
using Code.Gameplay.Features.Animations.Configs;
using Code.Gameplay.Features.Animations.Factory;
using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class CreateAnimationForDodgeStatusSystem : IExecuteSystem
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly IGroup<GameEntity> _effects;
        private readonly IGroup<GameEntity> _statuses;

        public CreateAnimationForDodgeStatusSystem(GameContext game, IAnimationFactory animationFactory)
        {
            _animationFactory = animationFactory;

            _effects = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Effect,
                    GameMatcher.DamageEffect,
                    GameMatcher.TargetId,
                    GameMatcher.ProducerId
                ));

            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.DamageAbsorption,
                    GameMatcher.DodgeStatus,
                    GameMatcher.ProducerId
                ));
        }

        public void Execute()
        {
            foreach (var effect in _effects)
            foreach (var _ in _statuses)
            {
                _animationFactory.CreateAnimation(
                    new AnimationSetup(AnimationTypeId.Dodge),
                    effect.TargetId,
                    effect.ProducerId);
            }
        }
    }
}
