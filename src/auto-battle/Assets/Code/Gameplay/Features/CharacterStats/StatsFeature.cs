﻿using Code.Gameplay.Features.CharacterStats.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.CharacterStats
{
    public class StatsFeature : Feature
    {
        public StatsFeature(ISystemFactory systems)
        {
            Add(systems.Create<StatChangeSystem>());
            
            Add(systems.Create<ApplyDamageFromStats>());
            Add(systems.Create<ApplyAgilityFromStats>());
        }
    }
}
