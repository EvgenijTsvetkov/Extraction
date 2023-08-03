using Source.Character;
using UnityEngine;

namespace Source
{
    public class WorldObjectsCollector : IWorldObjectsCollector
    {
        public Transform ContainerForItems { get; set; }
        public ISpawnPoint CharacterSpawnPoint { get; set; }
    }
}