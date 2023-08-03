using UnityEngine;

namespace Source
{
    public class ItemMarker : MonoBehaviour
    {
        [SerializeField] private ItemType _itemType;
        
        public ItemType ItemType => _itemType;
    }
}
