using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Fight.Systems
{
    public class ChangeTurnSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _fights;

        public ChangeTurnSystem(GameContext game, IStaticDataService staticDataService)
        {
            _fights = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fight,
                    GameMatcher.CooldownUp,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId
                    ));
        }

        public void Execute()
        {
            foreach (var fight in _fights)
            {
                var targetId = fight.TargetId;
                var producerId = fight.ProducerId;
                fight.ReplaceTargetId(producerId);
                fight.ReplaceProducerId(targetId);
            }
        }
    }
}
