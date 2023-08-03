using Source.Character;
using Source.Data;
using Source.Game;
using Source.Services;
using Zenject;

namespace Source
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGame();
            
            BindObjectsCollector();
            BindLogPool();
            
            BindProviders();
            BindServices();
            BindFactories();
        }

        private void BindGame()
        {
            Container.Bind<IGameProvider>().To<GameProvider>().AsSingle();
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();

            Container.Bind<IInitializable>().To<GameRunner>().AsTransient();
        }

        private void BindObjectsCollector()
        {
            Container.Bind<IWorldObjectsCollector>().To<WorldObjectsCollector>().AsSingle();
        }

        private void BindProviders()
        {
            BindConfigsProvider();
            BindAssetProvider();
            BindVirtualCameraProvider();
            BindCharacterProvider();
        }

        private void BindServices()
        {
            BindInputService();
            BindExtractionItemsService();
            BindUnloadingItemsService();
        }

        private void BindFactories()
        {
            BindCharacterFactory();
            BindCamerasFactory();
            BindLogFactory();
        }

        private void BindInputService()
        {
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
        }

        private void BindExtractionItemsService()
        {
            Container.BindInterfacesTo<ExtractionItemsService>().AsSingle();
        }

        private void BindUnloadingItemsService()
        {
            Container.BindInterfacesTo<UnloadingItemsService>().AsSingle();
        }

        private void BindCharacterFactory()
        {
            Container.Bind<ICharacterFactory>().To<CharacterFactory>().AsSingle();
        }

        private void BindCamerasFactory()
        {
            Container.Bind<IVirtualCamerasFactory>().To<VirtualCamerasFactory>().AsSingle();
        }

        private void BindLogFactory()
        {
            Container.Bind<IItemFactory>().To<ItemFactory>().AsSingle();
        }

        private void BindConfigsProvider()
        {
            Container.Bind<IConfigsProvider>().To<ConfigsProvider>().AsSingle();
        }

        private void BindAssetProvider()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }

        private void BindVirtualCameraProvider()
        {
            Container.Bind<IVirtualCameraProvider>().To<VirtualCameraProvider>().AsSingle();
        }

        private void BindCharacterProvider()
        {
            Container.Bind<ICharacterProvider>().To<CharacterProvider>().AsSingle();
        }
        
        private void BindLogPool()
        {
            Container.Bind<IItemPool>().To<ItemPool>().AsSingle();
        }
    }
}