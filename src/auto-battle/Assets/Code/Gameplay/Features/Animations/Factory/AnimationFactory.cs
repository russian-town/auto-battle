using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Animations.Configs;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Animations.Factory
{
    public class AnimationFactory : IAnimationFactory
    {
        private readonly IIdentifierService _identifiers;

        public AnimationFactory(IIdentifierService identifiers) => _identifiers = identifiers;

        public GameEntity CreateAnimation(AnimationSetup setup, int producerId, int targetId)
        {
            return CreateEntity.Empty("Animation")
                .AddId(_identifiers.Next())
                .With(x => x.isAnimation = true)
                .AddCurrentFrame(0f)
                .AddAllFrames(setup.AllFrames)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddHashCode(setup.HashCode)
                .AddDurationTime(setup.DurationTime)
                .AddTransitionTime(setup.TransitionTime)
                .With(x => x.AddAnimationEvents(setup.AnimationEvents), when: !setup.AnimationEvents.IsNullOrEmpty());
        }
    }
}
