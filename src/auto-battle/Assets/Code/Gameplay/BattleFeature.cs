﻿using Code.Common.Destruct;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Effect;
using Code.Gameplay.Features.Fight;
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
            Add(systems.Create<FightFeature>());
            Add(systems.Create<BindViewFeature>());

            Add(systems.Create<AbilityFeature>());
            
            Add(systems.Create<EffectFeature>());
            Add(systems.Create<StatusFeature>());
            
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<RotationFeature>());
            
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}
