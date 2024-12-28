using Code.Common.Entity;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public class ArmamentFactory : IArmamentFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;

        public ArmamentFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateBlock(AbilityId abilityId, int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(abilityId, level);
            
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddEffectSetups(abilityLevel.EffectSetups);
        }
    }
}
