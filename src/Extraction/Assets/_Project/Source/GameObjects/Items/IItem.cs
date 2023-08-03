namespace Source
{
    public interface IItem : IGameObject, IPoolObject
    {
        ItemType Type { get; }
    }
}