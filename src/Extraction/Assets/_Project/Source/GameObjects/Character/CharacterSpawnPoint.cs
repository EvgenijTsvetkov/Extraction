using UnityEngine;

namespace Source.Character
{
    public class CharacterSpawnPoint : MonoBehaviour, ISpawnPoint
    {
        private Transform _selfTransform;
        
        public Transform SelfTransform => _selfTransform;

        private void Awake()
        {
            _selfTransform = transform;
        }
    }
}
