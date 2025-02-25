using Code.Infrastructure.Views.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Animations.Registrars
{
    public class AnimatorStateInfoRegistrar : EntityComponentRegistrar
    {
        public Animator Animator;
        
        public override void RegisterComponents() =>
            Entity.AddAnimatorStateInfo(Animator.GetCurrentAnimatorStateInfo(0));

        public override void UnregisterComponents()
        {
            if (Entity.hasAnimatorStateInfo)
                Entity.RemoveAnimatorStateInfo();
        }
    }
}
