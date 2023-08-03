using Source.Character;
using Source.Data;
using UnityEngine;
using Zenject;

namespace Source.Services
{
    public class ExtractionItemsService : IExtractionItemsService, ITickable
    {
        private ICharacterProvider _characterProvider;
        private IConfigsProvider _configsProvider;
        
        private ItemType _extractionType;
        private float _extractionTime;
        private float _multiplier = 1;

        private ICharacter Character => _characterProvider.Value;
        private IExtractConfig ExtractConfig => _configsProvider.ExtractConfig;

        private bool HasExtract { get; set; }

        [Inject]
        public void Construct(ICharacterProvider characterProvider, IConfigsProvider configsProvider)
        {
            _characterProvider = characterProvider;
            _configsProvider = configsProvider;
        }
        
        public void Tick()
        {
            if (HasExtract == false)
                return;

            TryExtract();
        }
        
        public void BeganExtract(ItemType itemType)
        {
            HasExtract = true;
            
            _extractionType = itemType;

            CalculateExtractionTime();
        }

        public void EndExtract()
        {
            HasExtract = false;
        }

        public void SetMultiplier(float multiplier)
        {
            _multiplier = multiplier;
        }

        private void TryExtract()
        {
            if (Time.time < _extractionTime)
                return;

            Extract();
            CalculateExtractionTime();
        }

        private void Extract()
        {
            Character.GetItem(_extractionType);
        }

        private void CalculateExtractionTime()
        {
            _extractionTime = Time.time + ExtractConfig.Duractiom / _multiplier;
        }
    }
}
