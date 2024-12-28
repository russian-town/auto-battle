using Code.Gameplay.Features.Abilities;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public interface IArmamentFactory
    {
        GameEntity CreateBlock(AbilityId abilityId, int level);
    }
}
