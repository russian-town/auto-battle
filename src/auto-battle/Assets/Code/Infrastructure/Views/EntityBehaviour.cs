using Code.Gameplay.Common.Animations;
using Code.Gameplay.Common.Animations.Registry;
using Code.Gameplay.Common.Collisions;
using Code.Infrastructure.Views.Registrars;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Views
{
    public class EntityBehaviour : MonoBehaviour, IEntityView
    {
        private GameEntity _entity;
        private ICollisionRegistry _collisionRegistry;
        private IAnimatorRegistry _animatorRegistry;

        public GameEntity Entity => _entity;

        [Inject]
        public void Construct(ICollisionRegistry collisionRegistry, IAnimatorRegistry animatorRegistry)
        {
            _collisionRegistry = collisionRegistry;
            _animatorRegistry = animatorRegistry;
        }

        public void SetEntity(GameEntity entity)
        {
            _entity = entity;
            _entity.AddView(this);
            _entity.Retain(this);

            foreach (var registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.RegisterComponents();

            foreach (var collider in GetComponentsInChildren<Collider>(includeInactive: true))
                _collisionRegistry.Register(collider.GetInstanceID(), _entity);

            _animatorRegistry.Register(
                GetComponentInChildren<Animator>(includeInactive: true)
                    .GetInstanceID(), _entity);
        }

        public void ReleaseEntity()
        {
            foreach (var registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.UnregisterComponents();

            foreach (var collider in GetComponentsInChildren<Collider>(includeInactive: true))
                _collisionRegistry.Unregister(collider.GetInstanceID());

            _animatorRegistry.Unregister(
                GetComponentInChildren<Animator>(includeInactive: true)
                    .GetInstanceID());

            _entity.Release(this);
            _entity = null;
        }
    }
}
