using JetBrains.Annotations;
using Source.Services;
using UnityEngine;
using Zenject;

namespace Source.Character
{
    [RequireComponent(typeof(CharacterBag))]
    public class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] private TriggerObserver _triggerObserver;

        private IExtractionItemsService _extractionItemsService;
        private IUnloadingItemsService _unloadingItemsService;
        private IItemPool _itemPool;
        
        private CharacterBag _characterBag;
        private Transform _selfTransform;

        public Transform SelfTransform => _selfTransform;
        public bool HasEmptyBag => _characterBag.IsEmpty;

        [Inject]
        public void Construct(IExtractionItemsService extractionItemsService, IUnloadingItemsService unloadingItemsService,
            IItemPool itemPool)
        {
            _extractionItemsService = extractionItemsService;
            _unloadingItemsService = unloadingItemsService;
            _itemPool = itemPool;
        }

        private void Awake()
        {
            _selfTransform = transform;
            _characterBag = GetComponent<CharacterBag>();

            SubscribeOnEvents();
        }

        public async void GetItem(ItemType itemType)
        {
            if (_characterBag.CanAdd() == false)
                return;

            IItem item = await _itemPool.Get(itemType);
            _characterBag.Add(item);
        }

        public IItem RemoveItem()
        {
            IItem item = _characterBag.RemoveFirst();
            _itemPool.Remove(item);

            return item;
        }

        private void SubscribeOnEvents()
        {
            _triggerObserver.TriggerEnter += OnEnterInteractableLayer;
            _triggerObserver.TriggerExit += OnExitInteractableLayer;
        }

        private void OnEnterInteractableLayer(GameObject interactableObject)
        {
            var itemMarker = interactableObject.GetComponent<ItemMarker>();
            if (itemMarker)
            {
                StartExtractionItem(itemMarker.ItemType);
                return;
            }
            
            var chest = interactableObject.GetComponent<Chest>();
            if (chest) 
                StartUnloadingItemsTo(chest);
        }

        private void OnExitInteractableLayer(GameObject interactableObject)
        {
            var itemMarker = interactableObject.GetComponent<ItemMarker>();
            if (itemMarker)
            {
                StopExtractionItem();
                return;
            }
            
            var chest = interactableObject.GetComponent<Chest>();
            if (chest) 
                StopUnloadingItemsTo(chest);
        }

        private void StartExtractionItem(ItemType itemMarkerItemType)
        {
            _extractionItemsService.BeganExtract(itemMarkerItemType);
        }

        private void StopExtractionItem()
        {
            _extractionItemsService.EndExtract();
        }

        private void StartUnloadingItemsTo(Chest chest)
        {
            chest.Open();
            
            _unloadingItemsService.BeganUnload();
        }

        private void StopUnloadingItemsTo(Chest chest)
        {
            chest.Close();
            
            _unloadingItemsService.EndUnload();  
        }
    }
}