using Code.Gameplay.Features.Cooldowns.System;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Cooldowns
{
    public class CooldownsFeature : Feature
    {
        public CooldownsFeature(ISystemFactory systems)
        {
            Add(systems.Create<CooldownSystem>());
        }
    }
}
