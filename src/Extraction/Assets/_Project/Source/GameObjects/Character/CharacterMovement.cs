using Source.Data;
using Source.Services;
using UnityEngine;
using Zenject;

namespace Source.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        
        private IInputService _inputService;
        private IConfigsProvider _configsProvide;

        [Inject]
        public void Construct(IInputService inputService, IConfigsProvider configsProvider)
        {
            _inputService = inputService;
            _configsProvide = configsProvider;
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = Camera.main.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;

            _characterController.Move(_configsProvide.CharacterConfig.MovementSpeed * movementVector * Time.deltaTime);
        }
    }
}