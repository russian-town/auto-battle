using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class SetContainerForChildEntitiesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _childes;
        private readonly List<GameEntity> _buffer = new(32);

        public SetContainerForChildEntitiesSystem(GameContext game)
        {
            _childes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Container,
                    GameMatcher.Transform
                    )
                .NoneOf(GameMatcher.HasContainer));
        }

        public void Execute()
        {
            foreach (var child in _childes.GetEntities(_buffer))
            {
                child.Transform.SetParent(child.Container);
                child.isHasContainer = true;
            }
        }
    }
}
