﻿using Code.Gameplay.Features.AnimationsQueue.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.AnimationsQueue
{
    public class AnimationsQueueFeature : Feature
    {
        public AnimationsQueueFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkEmptyAnimationsQueueSystem>());
            Add(systems.Create<MarkCompletedAbilitiesWithEmptyAnimationsQueueSystem>());
            
            Add(systems.Create<MoveNextAnimationsQueueSystem>());
            Add(systems.Create<CleanupEmptyAnimationsSystem>());
        }
    }
}
