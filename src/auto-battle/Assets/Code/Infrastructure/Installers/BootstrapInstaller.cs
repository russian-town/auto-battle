using Code.Gameplay.Common.Collisions;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Systems;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            BindServices();
            BindContexts();
            BindSystemFactory();
        }

        private void BindServices()
        {
            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
            Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
        }

        private void BindContexts()
        {
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
        }

        private void BindSystemFactory() =>
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();

        public void Initialize() { }
    }
}
