using Source.Services;
using Zenject;

namespace Source.UI
{
    public class ExtractionMultiplierSelector : MultiplierSelector
    {
        private IExtractionItemsService _extractionItemsService;

        [Inject]
        public void Construct(IExtractionItemsService extractionItemsService)
        {
            _extractionItemsService = extractionItemsService;
        }

        private void Start()
        {
            SwitchMultiplier(0);
        }

        protected override void SwitchMultiplier(int index)
        {
            base.SwitchMultiplier(index);

            if (Multipliers.Count < index + 1)
                return;

            _extractionItemsService.SetMultiplier(Multipliers[index]);
        }
        
    }
}