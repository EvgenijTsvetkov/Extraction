namespace Source.Services
{
    public interface IExtractionItemsService
    {
        void BeganExtract(ItemType itemMarkerItemType);
        void EndExtract();
        void SetMultiplier(float multiplier);
    }
}