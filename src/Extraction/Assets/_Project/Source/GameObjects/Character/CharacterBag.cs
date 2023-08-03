using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Source.Character
{
    public class CharacterBag : MonoBehaviour
    {
        [SerializeField] private Transform _containerForItems;
        
        private readonly Queue<IItem> _items = new Queue<IItem>();

        private Vector2 _itemSize = new Vector2(3f, 1f);
        private Vector3 _leftOffset = new Vector3(-1, 0, 0);
        private readonly Vector3 _upOffset = new Vector3(0, 0.15f, 0);

        private const int Size = 15;
        private const int Rows = 5;
        public bool IsEmpty => _items.Count == 0;

        public bool CanAdd()
        {
            return _items.Count < Size;
        }
        
        public void Add(IItem item)
        {
            item.SelfTransform.SetParent(_containerForItems);
            item.Activate();
            
            _items.Enqueue(item);

            UpdateItemsPosition();
        }

        public IItem RemoveFirst()
        {
            var item = _items.Dequeue();
            
            UpdateItemsPosition();

            return item;
        }

        private void UpdateItemsPosition()
        {
            List<IItem> items = _items.ToList();

            for (int i = 0; i < items.Count; i++)
            {
                var position = Vector3.zero + _upOffset * i;
                items[i].SelfTransform.localPosition = position;
                items[i].SelfTransform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}