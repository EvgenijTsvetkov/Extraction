using UnityEngine;

namespace Source.Character
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] public Animator _animator;

        private readonly int _moveHash = Animator.StringToHash("Walking");

        private void Update()
        {
            _animator.SetFloat(_moveHash, _characterController.velocity.magnitude, 0.1f, Time.deltaTime);
        }
    }
}