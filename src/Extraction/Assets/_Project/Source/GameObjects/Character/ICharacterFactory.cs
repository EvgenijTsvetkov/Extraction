using System.Threading.Tasks;
using UnityEngine;

namespace Source.Character
{
    public interface ICharacterFactory
    {
        Task<ICharacter> Create(Vector3 spawnPosition);
    }
}