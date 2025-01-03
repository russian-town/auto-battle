using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Fighter.Factory
{
    public class FighterFactory : IFighterFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;

        public FighterFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
        }
        
        public GameEntity CreateFighter()
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddDamage(1)
                .AddCurrentHealth(100)
                .AddMaxHealth(100)
                .With(x => x.isFighter = true);
        }
    }
}
