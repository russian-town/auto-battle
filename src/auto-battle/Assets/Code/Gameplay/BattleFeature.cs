using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Input;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(GameContext game)
        {
            Add(new MovementFeature(game));
            Add(new InputFeature(game));
            Add(new HeroFeature(game));
        }
    }
}
