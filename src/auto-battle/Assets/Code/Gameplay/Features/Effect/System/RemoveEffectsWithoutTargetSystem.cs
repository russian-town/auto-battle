using Entitas;

namespace Code.Gameplay.Features.Effect.System
{
    public class RemoveEffectsWithoutTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;

        public RemoveEffectsWithoutTargetSystem(GameContext game) =>
            _effects = game.GetGroup(GameMatcher.Effect);

        public void Execute()
        {
            foreach (var effect in _effects)
                if(effect.hasTargetId == false)
                    effect.Destroy();
        }
    }
}
