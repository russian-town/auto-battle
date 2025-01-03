﻿using Code.Gameplay.Features.Statuses.Configs;

namespace Code.Gameplay.Features.Statuses.Factory
{
    public interface IStatusFactory
    {
        GameEntity CreateStatus(StatusSetup setup, int producerId, int targetId);
    }
}
