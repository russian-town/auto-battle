using Code.Common.Entity;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Damage.Factory
{
    public class HealthBarFactory : IHealthBarFactory
    {
        private readonly IIdentifierService _identifiers;

        public HealthBarFactory(IIdentifierService identifiers) =>
            _identifiers = identifiers;

        public GameEntity CreateHealthBar(int targetId, Transform parent)
        {
            return CreateEntity.Empty("HealthBar")
                    .AddId(_identifiers.Next())
                    .AddTargetId(targetId)
                    .AddAnchoredPosition(Vector2.zero)
                    .AddParent(parent)
                    .AddViewPath("Gameplay/Damage/HealthBar/HP_Bar")
                ;
        }
    }
}
