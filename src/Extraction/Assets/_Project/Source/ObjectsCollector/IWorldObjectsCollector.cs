using Source.Character;
using UnityEngine;

namespace Source
{
    public interface IWorldObjectsCollector
    {
        Transform ContainerForItems { get; set; }
        ISpawnPoint CharacterSpawnPoint { get; set; }
    }
}