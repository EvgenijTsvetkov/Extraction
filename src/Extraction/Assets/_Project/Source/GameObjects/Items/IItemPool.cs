using System.Threading.Tasks;

namespace Source
{
    public interface IItemPool
    {
        Task CreatePool();
        Task<IItem> Get(ItemType type);
        void Remove(IItem item);
    }
}