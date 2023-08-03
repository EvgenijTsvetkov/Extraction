using System.Threading.Tasks;
using UnityEngine;

namespace Source
{
    public interface IItemFactory
    {
        Task<IItem> Create(Transform parent, ItemType type);
    }
}
