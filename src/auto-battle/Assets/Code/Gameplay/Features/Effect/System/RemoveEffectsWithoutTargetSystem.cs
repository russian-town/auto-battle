using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class RemoveEffectsWithoutTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;

        public RemoveEffectsWithoutTargetSystem(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Effect,
                    GameMatcher.TargetId
                    ));
        }

        public void Execute()
        {
            foreach (var effect in _effects)
            {
                var target = effect.Target();
                
                if(target == null)
                    effect.Destroy();
            }
        }
    }
}
