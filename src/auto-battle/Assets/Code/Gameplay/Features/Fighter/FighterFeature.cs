using Code.Gameplay.Features.Fighter.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Fighter
{
    public class FighterFeature : Feature
    {
        public FighterFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeFighterSystem>());
            Add(systems.Create<UpdateAnimatorStateInfoByFightersSystem>());
            Add(systems.Create<UpdateAnimatorClipInfoByFightersSystem>());
        }
    }
}
