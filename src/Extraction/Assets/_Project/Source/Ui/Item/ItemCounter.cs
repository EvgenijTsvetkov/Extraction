using TMPro;
using UnityEngine;
using Zenject;

namespace Source.UI
{
    public class ItemCounter : MonoBehaviour
    {
        [SerializeField] private ItemType _type;
        [SerializeField] private TMP_Text _counter;

        private IUnloadingItemsService _unloadingItemsService;

        private int _count;

        [Inject]
        public void Construct(IUnloadingItemsService unloadingItemsService)
        {
            _unloadingItemsService = unloadingItemsService;
        }

        private void Start()
        {
            UpdateCounter();
            SubscribeOnEvents();
        }

        private void OnDestroy()
        {
            UnsubscribeOnEvents();
        }

        private void UpdateCounter()
        {
            _counter.text = $"{_count}";
        }

        private void UnloadItemHandler(ItemType itemType)
        {
            if (itemType != _type)
                return;

            _count += 1;
            UpdateCounter();
        }

        private void UnsubscribeOnEvents()
        {
            _unloadingItemsService.OnUnloadItem -= UnloadItemHandler;
        }

        private void SubscribeOnEvents()
        {
            _unloadingItemsService.OnUnloadItem += UnloadItemHandler;
        }
    }
}