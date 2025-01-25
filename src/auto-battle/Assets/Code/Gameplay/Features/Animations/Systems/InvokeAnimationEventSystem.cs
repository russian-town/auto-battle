using System.Collections.Generic;
using Code.Gameplay.Features.Effect.Factory;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class InvokeAnimationEventSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _events;
        private readonly List<GameEntity> _buffer = new(32);

        public InvokeAnimationEventSystem(GameContext game, IEffectFactory effectFactory)
        {
            _game = game;
            _effectFactory = effectFactory;

            _events = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Event,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.EffectSetups,
                        GameMatcher.CaptureOnTimeline
                    )
                    .NoneOf(GameMatcher.Invoked));
        }

        public void Execute()
        {
            foreach (var eventComponent in _events.GetEntities(_buffer))
            {
                var parentAnimation = _game.GetEntityWithId(eventComponent.ParentAnimationId);

                if (parentAnimation.AnimationCurrentTime < eventComponent.CaptureOnTimeline)
                    continue;

                foreach (var effectSetup in eventComponent.EffectSetups)
                    _effectFactory.CreateEffect(effectSetup, eventComponent.ProducerId, eventComponent.TargetId);

                eventComponent.isInvoked = true;
            }
        }
    }
}
