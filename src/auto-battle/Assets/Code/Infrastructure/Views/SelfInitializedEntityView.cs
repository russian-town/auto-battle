using Code.Common.Entity;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Views
{
    public class SelfInitializedEntityView : MonoBehaviour
    {
        public EntityBehaviour EntityBehaviour;

        private IIdentifierService _identifiers;

        [Inject]
        public void Construct(IIdentifierService identifiers) =>
            _identifiers = identifiers;

        private void Awake()
        {
            var entity = CreateEntity.Empty("Entity")
                .AddId(_identifiers.Next());

            EntityBehaviour.SetEntity(entity);
        }
    }
}
