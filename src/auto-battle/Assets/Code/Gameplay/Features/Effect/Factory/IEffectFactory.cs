using Code.Gameplay.Features.Effect.Configs;

namespace Code.Gameplay.Features.Effect.Factory
{
    public interface IEffectFactory
    {
        GameEntity CreateEffect(EffectSetup setup, int producerId, int targetId);
    }
}
