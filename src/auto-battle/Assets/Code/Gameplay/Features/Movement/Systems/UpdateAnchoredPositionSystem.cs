using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class UpdateAnchoredPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public UpdateAnchoredPositionSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnchoredPosition,
                    GameMatcher.RectTransform
                ));
        }

        public void Execute()
        {
            foreach (var mover in _movers)
                mover.RectTransform.anchoredPosition = mover.AnchoredPosition;
        }
    }
}
