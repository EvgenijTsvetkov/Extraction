using Source.Character;
using UnityEngine;
using Zenject;

namespace Source
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private CharacterSpawnPoint _characterSpawnPoint;
        [SerializeField] private Transform _containerForItems;

        public override void InstallBindings()
        {
            var worldObjectsCollector = Container.Resolve<IWorldObjectsCollector>();
            worldObjectsCollector.CharacterSpawnPoint = _characterSpawnPoint;
            worldObjectsCollector.ContainerForItems = _containerForItems;
        }
    }
}