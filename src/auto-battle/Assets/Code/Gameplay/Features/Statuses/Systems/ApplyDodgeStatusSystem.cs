using System.Collections.Generic;
using Code.Gameplay.Features.Animations;
using Code.Gameplay.Features.Animations.Configs;
using Code.Gameplay.Features.Animations.Factory;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class ApplyDodgeStatusSystem : IExecuteSystem
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly IGroup<GameEntity> _statuses;
        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(32);

        public ApplyDodgeStatusSystem(GameContext game, IAnimationFactory animationFactory)
        {
            _animationFactory = animationFactory;
            
            _statuses = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Status,
                        GameMatcher.DodgeStatus,
                        GameMatcher.ProducerId
                    )
                    .NoneOf(GameMatcher.Affected));
            
            _effects = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Effect,
                    GameMatcher.DamageEffect,
                    GameMatcher.EffectValue,
                    GameMatcher.TargetId
                ));
        }

        public void Execute()
        {
            foreach (var status in _statuses.GetEntities(_buffer))
            foreach (var effect in _effects)
            {
                if (status.ProducerId != effect.TargetId)
                    continue;
                
                effect.ReplaceEffectValue(0);
                
                _animationFactory.CreateAnimation(
                    new AnimationSetup(AnimationTypeId.Dodge),
                    status.ProducerId,
                    status.TargetId);
                
                status.isAffected = true;
            }
        }
    }
}
