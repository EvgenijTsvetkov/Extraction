using System.Threading.Tasks;
using Source.Data.Constant;
using Source.Services;
using UnityEngine;

namespace Source.Character
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly ICharacterProvider _characterProvider;

        public CharacterFactory(IAssetProvider assetProvider, ICharacterProvider characterProvider)
        {
            _assetProvider = assetProvider;
            _characterProvider = characterProvider;
        }

        public async Task<ICharacter> Create(Vector3 spawnPosition)
        {
            _characterProvider.Value = await _assetProvider.InstantiateAsync<Character>(AddressableNames.Character);
            _characterProvider.Value.SelfTransform.position = spawnPosition;

            return _characterProvider.Value;
        }
    }
}