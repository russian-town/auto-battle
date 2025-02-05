using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class InterruptAnimationOnHitsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;
        private readonly IGroup<GameEntity> _animations;
        private readonly List<GameEntity> _buffer = new(64);

        public InterruptAnimationOnHitsSystem(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Effect,
                    GameMatcher.TargetId
                    ));
            
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.ProducerId
                    )
                .NoneOf(GameMatcher.AnimationEnded));
        }

        public void Execute()
        {
            foreach (var effect in _effects)
            foreach (var animation in _animations.GetEntities(_buffer))
            {
                if (effect.TargetId == animation.ProducerId)
                    animation.isAnimationEnded = true;
            }
        }
    }
}
