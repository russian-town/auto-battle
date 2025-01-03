using Code.Gameplay.Features.Abilities.Configs;

namespace Code.Gameplay.Features.Abilities.Factory
{
    public interface IAbilityFactory
    {
        GameEntity CreateAbility(AbilityConfig config, int producerId, int targetId);
    }
}
