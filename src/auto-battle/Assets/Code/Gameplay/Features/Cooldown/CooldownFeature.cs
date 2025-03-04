using Code.Gameplay.Features.Cooldown.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Cooldown
{
    public class CooldownFeature : Feature
    {
        public CooldownFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateCooldownSystem>());
        }
    }
}
