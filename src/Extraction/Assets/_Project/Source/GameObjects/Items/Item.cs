using UnityEngine;

namespace Source
{
    public class Item : MonoBehaviour, IItem
    {
        [SerializeField] private ItemType _type;
        
        private GameObject _selfGameObject;
        private Transform _selfTransform;

        public ItemType Type => _type;
        public Transform SelfTransform => _selfTransform;
        
        private void Awake()
        {
            _selfTransform = transform;
            _selfGameObject = gameObject;
        }

        public void Activate()
        {
            _selfGameObject.SetActive(true);
        }

        public void Deactivate()
        {
            _selfGameObject.SetActive(false);
        }
    }
}