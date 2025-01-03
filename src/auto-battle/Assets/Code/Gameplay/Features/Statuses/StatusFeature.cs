﻿using Code.Gameplay.Features.Statuses.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Statuses
{
    public class StatusFeature : Feature
    {
        public StatusFeature(ISystemFactory systems)
        {
            Add(systems.Create<ApplyStatusSetupSystem>());
            Add(systems.Create<CleanupUnappliedStatusesSystem>());
        }
    }
}