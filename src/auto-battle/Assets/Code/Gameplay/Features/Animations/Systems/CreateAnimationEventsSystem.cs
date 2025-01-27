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
                        GameMatcher.AnimationStarted,
                        GameMatcher.Id,
                        GameMatcher.AnimationTime,
                        GameMatcher.AnimationCurrentTime,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.EventSetups
                    )
                    .NoneOf(GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (var animation in _animations.GetEntities(_buffer))
            {
                foreach (var eventSetup in animation.EventSetups)
                {
                    CreateEntity.Empty()
                        .AddProducerId(animation.ProducerId)
                        .AddTargetId(animation.TargetId)
                        .With(x => x.AddEffectSetups(eventSetup.EffectSetups), when: !eventSetup.EffectSetups.IsNullOrEmpty())
                        .AddCaptureOnTimeline(eventSetup.CaptureOnTimeline)
                        .With(x => x.isEvent = true)
                        .AddParentAnimationId(animation.Id);
                }

                animation.isProcessed = true;
            }
        }
    }
}
