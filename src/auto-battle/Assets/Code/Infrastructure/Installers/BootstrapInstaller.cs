using Code.Common;
using Code.Gameplay.Common.Collisions;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Buffs.Factory;
using Code.Gameplay.Features.Damage.Factory;
using Code.Gameplay.Features.Effect.Factory;
using Code.Gameplay.Features.Fighter.Factory;
using Code.Gameplay.Features.Statuses.Factory;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
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
            BindGameplayServices();
            BindContexts();
            BindEntityIndices();
            BindSystemFactory();
            BindGameplayFactory();
        }

        private void BindServices()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
            Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
            Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<ITimeService>().To<TimeService>().AsSingle();
            Container.Bind<IRandomService>().To<RandomService>().AsSingle();
        }

        private void BindGameplayServices() { }

        private void BindContexts()
        {
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
        }
        
        private void BindEntityIndices() =>
            Container.BindInterfacesAndSelfTo<GameEntityIndices>().AsSingle();

        private void BindSystemFactory() =>
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();

        private void BindGameplayFactory()
        {
            Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
            Container.Bind<IEffectFactory>().To<EffectFactory>().AsSingle();
            Container.Bind<IStatusFactory>().To<StatusFactory>().AsSingle();
            Container.Bind<IFighterFactory>().To<FighterFactory>().AsSingle();
            Container.Bind<IAbilityFactory>().To<AbilityFactory>().AsSingle();
            Container.Bind<IHealthBarFactory>().To<HealthBarFactory>().AsSingle();
            Container.Bind<IBuffFactory>().To<BuffFactory>().AsSingle();
        }

        public void Initialize() { }
    }
}
