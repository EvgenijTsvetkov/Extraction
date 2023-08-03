using System.Threading.Tasks;
using Cinemachine;
using Source.Services;

namespace Source
{
    public class VirtualCamerasFactory : IVirtualCamerasFactory
    {
        private readonly IAssetProvider _assetProvider;

        public VirtualCamerasFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public async Task<CinemachineVirtualCamera> Create(string addressableName)
        {
            CinemachineVirtualCamera camera = await _assetProvider.InstantiateAsync<CinemachineVirtualCamera>(addressableName);

            return camera;
        }
    }
}