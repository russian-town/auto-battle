using Code.Gameplay.Features.Fighter.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Fighter
{
    public class FighterFeature : Feature
    {
        public FighterFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeFightersSystem>());
            
            Add(systems.Create<CreateAbilityByFightersSystem>());
        }
    }
}
