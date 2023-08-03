using UnityEngine;

namespace Source
{
    public class ChestAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private readonly int _openHash = Animator.StringToHash("IsOpen");
        
        public void PlayOpen()
        {
            _animator.SetBool(_openHash, true);
        }

        public void PlayClose()
        {
             _animator.SetBool(_openHash, false);
        }
    }
}