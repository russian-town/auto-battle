using Code.Common.Destruct;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Rotation;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;
using Code.Infrastructure.Views;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());
            
            Add(systems.Create<BindViewFeature>());
            
            Add(systems.Create<HeroFeature>());
            
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<RotationFeature>());
            
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}
