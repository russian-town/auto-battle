using Code.Gameplay.Common.Collisions;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Levels;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Systems;
using Code.Infrastructure.Views.Factory;
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
            BindGameplayFactory();
        }

        private void BindServices()
        {
            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
            Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
            Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<ITimeService>().To<TimeService>().AsSingle();
        }

        private void BindContexts()
        {
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
        }

        private void BindSystemFactory() =>
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();

        private void BindGameplayFactory()
        {
            Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
            Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
            Container.Bind<IArmamentFactory>().To<ArmamentFactory>().AsSingle();
            Container.Bind<IAbilityFactory>().To<AbilityFactory>().AsSingle();
        }

        public void Initialize() { }
    }
}
