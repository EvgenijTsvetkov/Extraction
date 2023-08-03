using Zenject;

namespace Source.UI
{
    public class UnloadingMultiplierSelector : MultiplierSelector
    {
        private IUnloadingItemsService _unloadingItemsService;

        [Inject]
        public void Construct(IUnloadingItemsService unloadingItemsService)
        {
            _unloadingItemsService = unloadingItemsService;
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

            _unloadingItemsService.SetMultiplier(Multipliers[index]);
        }
    }
}