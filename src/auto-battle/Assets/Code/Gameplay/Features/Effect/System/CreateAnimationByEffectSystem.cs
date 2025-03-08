using System.Collections.Generic;
using Code.Gameplay.Features.Animations.Factory;
using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class CreateAnimationByEffectSystem : IExecuteSystem
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(32);

        public CreateAnimationByEffectSystem(GameContext game, IAnimationFactory animationFactory)
        {
            _animationFactory = animationFactory;
            
            _effects = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Effect,
                    GameMatcher.TargetId,
                    GameMatcher.AnimationSetup
                    )
                .NoneOf(GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (var effect in _effects.GetEntities(_buffer))
            {
                _animationFactory.CreateAnimation(effect.AnimationSetup, effect.TargetId, effect.TargetId);
            }
        }
    }
}
