using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class SetHeroDirectionByInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _inputs;
        private readonly IGroup<GameEntity> _heroes;

        public SetHeroDirectionByInputSystem(GameContext game)
        {
            _inputs = game.GetGroup(GameMatcher.Input);
            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero));
        }

        public void Execute()
        {
            foreach (var input in _inputs)
            foreach (var hero in _heroes)
            {
                hero.isMoving = input.hasAxisInput;

                if (input.hasAxisInput)
                    hero.ReplaceDirection(new Vector3(input.AxisInput.x, 0f, input.AxisInput.y).normalized);
            }
        }
    }
}
