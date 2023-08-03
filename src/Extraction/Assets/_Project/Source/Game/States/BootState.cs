using System.Threading.Tasks;
using Source.Data;
using Source.Data.Constant;
using Source.Services;

namespace Source.Game
{
    public class BootState : GameState
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IConfigsProvider _configsProvider;
        private readonly IVirtualCamerasFactory _camerasFactory;
        private readonly IVirtualCameraProvider _virtualCameraProvider;
        private readonly IItemPool _itemPool;

        public BootState(IGameProvider gameProvider, IAssetProvider assetProvider, IConfigsProvider configsProvider, 
            IVirtualCamerasFactory camerasFactory, IVirtualCameraProvider virtualCameraProvider, IItemPool itemPool) : base(gameProvider)
        {
            _assetProvider = assetProvider;
            _configsProvider = configsProvider;
            _camerasFactory = camerasFactory;
            _virtualCameraProvider = virtualCameraProvider;
            _itemPool = itemPool;
        }

        public override async void Enter()
        {
            base.Enter();

            await LoadAssets();
            await CreateCameras();
            await CreateItems();
            
            GameToGameLoopState();
        }

        private async Task CreateCameras()
        {
            _virtualCameraProvider.Value = await _camerasFactory.Create(AddressableNames.FollowCamera);
        }

        private async Task LoadAssets()
        {
            _configsProvider.CharacterConfig =
                await _assetProvider.LoadAssetAsync<ICharacterConfig>(AddressableNames.CharacterConfig);
            
            _configsProvider.ExtractConfig =
                await _assetProvider.LoadAssetAsync<IExtractConfig>(AddressableNames.ExtractConfig);
        }
        
        private async Task CreateItems()
        {
            await _itemPool.CreatePool();
        }

        private void GameToGameLoopState()
        {
            Game.SwitchState<GameLoopState>();
        }
    }
}
