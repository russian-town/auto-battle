using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Buffs;
using Code.Gameplay.Features.Buffs.Configs;
using Code.Gameplay.Features.Fighter.Configs;

namespace Code.Gameplay.StaticData
{
    public interface IStaticDataService
    {
        void LoadAll();
        AbilityConfig GetAbilityConfig(AbilityTypeId abilityTypeId);
        FighterConfig GetFighterConfig();
        BuffConfig GetBuffConfig(BuffTypeId typeId);
    }
}
