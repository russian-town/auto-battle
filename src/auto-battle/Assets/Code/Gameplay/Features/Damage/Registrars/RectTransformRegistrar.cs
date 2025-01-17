using Code.Infrastructure.Views.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Damage.Registrars
{
    public class RectTransformRegistrar : EntityComponentRegistrar
    {
        public RectTransform RectTransform;
        
        public override void RegisterComponents() =>
            Entity.AddRectTransform(RectTransform);

        public override void UnregisterComponents()
        {
            if (Entity.hasRectTransform)
                Entity.RemoveRectTransform();
        }
    }
}
