using Code.Gameplay.Features.Fight.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Fight
{
    public class FightFeature : Feature
    {
        public FightFeature(ISystemFactory systems)
        {
            Add(systems.Create<ChangeTurnSystem>());
        }
    }
}
