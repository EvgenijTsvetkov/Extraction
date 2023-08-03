using System;

namespace Source
{
    public interface IUnloadingItemsService
    {
        event Action<ItemType> OnUnloadItem;
        
        void BeganUnload();
        void EndUnload();
        void SetMultiplier(float multiplier);
    }
}