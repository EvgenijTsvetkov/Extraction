using UnityEngine;

namespace Source
{
    public class Chest : MonoBehaviour
    {
        [SerializeField] private ChestAnimator _chestAnimator;
        
        public void Open()
        {
            _chestAnimator.PlayOpen();
        }

        public void Close()
        {
            _chestAnimator.PlayClose();
        }
    }
}
