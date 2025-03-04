using Code.Common.Destruct;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Animations;
using Code.Gameplay.Features.Buffs;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.Features.Effect;
using Code.Gameplay.Features.Fighter;
using Code.Gameplay.Features.HealthBar;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Rotation;
using Code.Gameplay.Features.Statuses;
using Code.Infrastructure.Systems;
using Code.Infrastructure.Views;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        { 
            Add(systems.Create<CooldownFeature>());
            Add(systems.Create<BindViewFeature>());
            
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<RotationFeature>());
            
            Add(systems.Create<FighterFeature>());
            Add(systems.Create<AbilityFeature>());
            Add(systems.Create<BuffFeature>());
            
            Add(systems.Create<AnimationFeature>());
            
            Add(systems.Create<StatusFeature>());
            Add(systems.Create<EffectFeature>());
            Add(systems.Create<StatsFeature>());
            
            Add(systems.Create<HealthBarFeature>());
            
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}
