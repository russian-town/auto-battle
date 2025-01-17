using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class SetParentFromEntitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _childes;
        private readonly List<GameEntity> _buffer = new(2);

        public SetParentFromEntitySystem(GameContext game)
        {
            _childes = game.GetGroup(GameMatcher
                    .AllOf(
                        GameMatcher.Parent,
                        GameMatcher.RectTransform
                    )
                    .NoneOf(GameMatcher.ParentInitialized));
        }

        public void Execute()
        {
            foreach (var child in _childes.GetEntities(_buffer))
            {
                child.isParentInitialized = true;
                child.RectTransform.SetParent(child.Parent);
            }
        }
    }
}
