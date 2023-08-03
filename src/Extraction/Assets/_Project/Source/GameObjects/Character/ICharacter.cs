namespace Source.Character
{
    public interface ICharacter : IGameObject
    {
        bool HasEmptyBag { get; }
        
        void GetItem(ItemType itemType);
        IItem RemoveItem();
    }
}