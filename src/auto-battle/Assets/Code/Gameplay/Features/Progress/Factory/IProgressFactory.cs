using Code.Gameplay.Features.Progress.Config;

namespace Code.Gameplay.Features.Progress.Factory
{
    public interface IProgressFactory
    {
        GameEntity CreateProgress(ProgressSetup setup, int producerId, int targetId);
    }
}
