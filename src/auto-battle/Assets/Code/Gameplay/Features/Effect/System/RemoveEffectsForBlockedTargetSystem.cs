using System.Collections.Generic;
using Code.Gameplay.Features.Animations;
using Code.Gameplay.Features.Animations.Configs;
using Code.Gameplay.Features.Animations.Factory;
using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class RemoveEffectsForBlockedTargetSystem : IExecuteSystem
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly IGroup<GameEntity> _effects;
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new(32);

        public RemoveEffectsForBlockedTargetSystem(GameContext game, IAnimationFactory animationFactory)
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
                        GameMatcher.BlockStatus,
                        GameMatcher.ProducerId
                    ));
        }

        public void Execute()
        {
            foreach (var effect in _effects.GetEntities(_buffer))
            foreach (var status in _statuses)
            {
                if (effect.TargetId != status.ProducerId)
                    continue;

                _animationFactory.CreateAnimation(
                    new AnimationSetup(AnimationTypeId.Block),
                    effect.TargetId,
                    effect.ProducerId);

                effect.Destroy();
            }
        }
    }
}
