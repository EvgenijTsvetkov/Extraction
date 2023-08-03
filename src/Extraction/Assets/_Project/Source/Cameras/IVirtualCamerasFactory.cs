using System.Threading.Tasks;
using Cinemachine;

namespace Source
{
    public interface IVirtualCamerasFactory
    {
        Task<CinemachineVirtualCamera> Create(string addressableName);
    }
}