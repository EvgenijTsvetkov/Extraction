using UnityEngine;
using static Source.Data.Constants;

namespace Source.Data
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = ProjectName + "/Character Config")]
    public class CharacterConfig : ScriptableObject, ICharacterConfig
    {
        [Range(1, 10)] 
        [SerializeField] private float _movementSpeed = 3;

        public float MovementSpeed => _movementSpeed;
    }
}
