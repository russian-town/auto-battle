using Code.Infrastructure.Views.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Registrars
{
    public class AnimatorClipInfoRegistrar : EntityComponentRegistrar
    {
        public Animator Animator;
        
        public override void RegisterComponents()
        {
            var animatorClipInfos = Animator.GetCurrentAnimatorClipInfo(0);
            Entity.AddAnimatorClipInfo(animatorClipInfos[0]);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasAnimatorClipInfo)
                Entity.RemoveAnimatorClipInfo();
        }
    }
}
