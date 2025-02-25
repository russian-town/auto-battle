using Entitas;

namespace Code.Gameplay.Common.Animations.Registry
{
    public interface IAnimatorRegistry
    {
        void Register(int instanceId, IEntity entity);
        void Unregister(int instanceId);
        TEntity Get<TEntity>(int instanceId) where TEntity : class;
    }
}
