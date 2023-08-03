using System.Threading.Tasks;
using Source.Character;
using UnityEngine;

namespace Source.Game
{
    public class GameLoopState : GameState
    {
        private readonly IWorldObjectsCollector _worldObjectsCollector;
        private readonly ICharacterFactory _characterFactory;
        private readonly IVirtualCameraProvider _cameraProvider;

        public GameLoopState(IGameProvider gameProvider, IWorldObjectsCollector worldObjectsCollector,
            ICharacterFactory characterFactory, IVirtualCameraProvider cameraProvider) : base(gameProvider)
        {
            _worldObjectsCollector = worldObjectsCollector;
            _characterFactory = characterFactory;
            _cameraProvider = cameraProvider;
        }

        public override async void Enter()
        {
            base.Enter();

            await SpawnCharacter();
        }
        
        private async Task SpawnCharacter()
        {
            Vector3 spawnPosition = _worldObjectsCollector.CharacterSpawnPoint.SelfTransform.position;
            ICharacter character = await _characterFactory.Create(spawnPosition);

            _cameraProvider.Value.Follow = character.SelfTransform;
            _cameraProvider.Value.LookAt = character.SelfTransform;
        }
    }
}