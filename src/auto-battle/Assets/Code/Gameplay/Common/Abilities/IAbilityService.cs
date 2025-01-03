using Code.Gameplay.Features.Abilities.Configs;

namespace Code.Gameplay.Common.Abilities
{
    public interface IAbilityService
    {
        void LoadAll();
        AbilityConfig GetRandomAbilities();
    }
}
