using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
    public class CreateAnimationEventsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _animations;
        private readonly List<GameEntity> _buffer = new(32);

        public CreateAnimationEventsSystem(GameContext game)
        {
            _animations = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Animation,
                    GameMatcher.Id,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.HashCode,
                    GameMatcher.AnimationEvents
                    )
                .NoneOf(GameMatcher.AnimationEventsCreated));
        }

        public void Execute()
        {
            foreach (var animation in _animations.GetEntities(_buffer))
            {
                foreach (var animationEvent in animation.AnimationEvents)
                {
                    CreateEntity.Empty("AnimationEvent")
                        .AddTargetFrame(animationEvent.TargetFrame)
                        .With(
                            x => x.AddEffectSetups(animationEvent.EffectSetups),
                            when: !animationEvent.EffectSetups.IsNullOrEmpty())
                        .With(
                            x => x.AddStatusSetups(animationEvent.StatusSetups),
                            when: !animationEvent.StatusSetups.IsNullOrEmpty())
                        .With(x => x.isAnimationEvent = true)
                        .AddAnimationLinkedId(animation.Id)
                        .AddProducerId(animation.ProducerId)
                        .AddTargetId(animation.TargetId)
                        .AddHashCode(animation.HashCode)
                        ;
                }

                animation.isAnimationEventsCreated = true;
            }
        }
    }
}
