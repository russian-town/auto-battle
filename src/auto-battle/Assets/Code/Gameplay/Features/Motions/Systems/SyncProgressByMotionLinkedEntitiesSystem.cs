using Entitas;

namespace Code.Gameplay.Features.Motions.Systems
{
    public class SyncProgressByMotionLinkedEntitiesSystem : Entitas.IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _motions;

        public SyncProgressByMotionLinkedEntitiesSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Progress,
                    GameMatcher.MotionQueueLinkedId
                    ));
            
            _motions = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Progress,
                    GameMatcher.Id
                    ));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            foreach (var motion in _motions)
            {
                if (entity.MotionQueueLinkedId == motion.Id)
                    entity.ReplaceProgress(motion.Progress);
            }
        }
    }
}
