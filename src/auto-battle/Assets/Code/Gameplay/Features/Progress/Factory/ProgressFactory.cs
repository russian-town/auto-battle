using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Motions;
using Code.Gameplay.Features.Progress.Config;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Progress.Factory
{
    public class ProgressFactory : IProgressFactory
    {
        private readonly IIdentifierService _identifiers;

        public ProgressFactory(IIdentifierService identifiers) => _identifiers = identifiers;

        public GameEntity CreateProgress(ProgressSetup setup, int producerId, int targetId)
        {
            return CreateEntity.Empty("Progress")
                .AddId(_identifiers.Next())
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddSpeed(setup.Speed)
                .AddNormalizedTime(0f)
                .AddCurrentFrame(0f)
                .With(x => x.isInvoke = true, when: setup.MotionSetup == null)
                .With(x => x.AddHashCode(Animator.StringToHash(setup.MotionSetup.MotionName)), when: setup.MotionSetup != null)
                .With(x => x.AddEventFrame(setup.MotionSetup.EventFrame), when: setup.MotionSetup != null)
                .With(x => x.AddMaxFrame(setup.MotionSetup.MaxFrame), when: setup.MotionSetup != null)
                .With(x => x.AddEffectSetups(setup.MotionSetup.EffectSetups), when: setup.MotionSetup != null && !setup.MotionSetup.EffectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(setup.MotionSetup.StatusSetups), when: setup.MotionSetup != null && !setup.MotionSetup.StatusSetups.IsNullOrEmpty())
                ;
        }
    }
}
