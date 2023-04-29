using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace PurpleSlayerFish.Core.Services.Input
{
    public class PlayerInputAdapter : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        
        [Inject] private IInputProvider<InputData> _inputProvider;

        private void Start()
        {
            var actions = _playerInput.actions;
            actions["HorizontalAxis"].performed += OnHorizontal;
            actions["HorizontalAxis"].canceled += OnHorizontal;
            actions["VerticalAxis"].performed += OnVertical;
            actions["VerticalAxis"].canceled += OnVertical;
            actions["Space"].performed += OnSpace;
            actions["Escape"].performed += OnEscape;
        }

        private void OnDestroy()
        {
            var actions = _playerInput.actions;
            actions["HorizontalAxis"].performed -= OnHorizontal;
            actions["HorizontalAxis"].canceled -= OnHorizontal;
            actions["VerticalAxis"].performed -= OnVertical;
            actions["VerticalAxis"].canceled -= OnVertical;
            actions["Space"].performed -= OnSpace;
            actions["Escape"].performed -= OnEscape;
        }

        private void OnHorizontal(InputAction.CallbackContext ctx) => _inputProvider.Data.HorizontalAxis = ctx.ReadValue<float>();
        private void OnVertical(InputAction.CallbackContext ctx) => _inputProvider.Data.VerticalAxis = ctx.ReadValue<float>();
        private void OnSpace(InputAction.CallbackContext ctx) => _inputProvider.Data.OnSpace?.Invoke();
        private void OnEscape(InputAction.CallbackContext ctx) => _inputProvider.Data.OnEscape?.Invoke();
    }
}