using Code.Common.Entity;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IIdentifierService _identifiers;

        public HeroFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }
        
        public GameEntity CreateHero(Vector3 at, Quaternion rotation)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddWorldPosition(at)
                .AddWorldRotation(rotation)
                .AddDirection(Vector3.zero)
                .AddViewPath("Gameplay/Hero/Ninja")
                .AddSpeed(2);
        }
    }
}
