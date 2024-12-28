using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Abilities.Factory
{
    public class AbilityFactory : IAbilityFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;

        public AbilityFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateBlock()
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .With(x => x.isBlockAbility = true)
                ;
        }
    }
}
