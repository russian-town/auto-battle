using System.Collections.Generic;
using Code.Gameplay.Features.Animations;
using Code.Gameplay.Features.Animations.Configs;
using Code.Gameplay.Features.Animations.Factory;
using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class ProcessDefaultAttackDamageEffectSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IAnimationFactory _animationFactory;
        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(64);

        public ProcessDefaultAttackDamageEffectSystem(GameContext game, IAnimationFactory animationFactory)
        {
            _game = game;
            _animationFactory = animationFactory;

            _effects = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.DamageEffect,
                        GameMatcher.EffectValue,
                        GameMatcher.TargetId,
                        GameMatcher.ProducerId
                    )
                    .NoneOf(GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (var effect in _effects.GetEntities(_buffer))
            {
                var target = _game.GetEntityWithId(effect.TargetId);
                
                _animationFactory.CreateAnimation(
                    new AnimationSetup(AnimationTypeId.Hit, .36f, 0f),
                    effect.TargetId,
                    effect.TargetId);
                
                target.ReplaceCurrentHealth(target.CurrentHealth - effect.EffectValue);
                effect.isProcessed = true;
            }
        }
    }
}
