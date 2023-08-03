using System;
using Source.Character;
using Source.Data;
using UnityEngine;
using Zenject;

namespace Source
{
    public class UnloadingItemsService : IUnloadingItemsService, ITickable
    {
        private ICharacterProvider _characterProvider;
        private IConfigsProvider _configsProvider;
        
        private float _unloadingTime;
        private float _multiplier = 1;
        
        private ICharacter Character => _characterProvider.Value;
        private IExtractConfig ExtractConfig => _configsProvider.ExtractConfig;
        
        private bool HasUnloading { get; set; }
        
        public event Action<ItemType> OnUnloadItem;
        
        [Inject]
        public void Construct(ICharacterProvider characterProvider, IConfigsProvider configsProvider)
        {
            _characterProvider = characterProvider;
            _configsProvider = configsProvider;
        }
        
        public void Tick()
        {
            if (HasUnloading == false)
                return;

            TryUnload();
        }

        public void BeganUnload()
        {
            HasUnloading = true;
        }

        public void EndUnload()
        {
            HasUnloading = false;
        }

        public void SetMultiplier(float multiplier)
        {
            _multiplier = multiplier;
        }

        private void TryUnload()
        {
            if (Time.time < _unloadingTime)
                return;

            Unload();
            CalculateUnloadTime();
        }

        private void Unload()
        {
            if (Character.HasEmptyBag)
                return;

            var item = Character.RemoveItem();
            OnUnloadItem?.Invoke(item.Type);
        }

        private void CalculateUnloadTime()
        {
            _unloadingTime = Time.time + ExtractConfig.Duractiom / _multiplier;
        }
    }
}