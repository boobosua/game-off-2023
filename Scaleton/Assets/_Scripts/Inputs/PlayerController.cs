using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Scaleton
{
    [CreateAssetMenu(fileName = "NewController", menuName = "Controller/Input Controller")]
    public class PlayerController : ScriptableObject, Controls.IGameplayActions
    {
        private Controls _controls;
        private Gamepad _gamepad;

        public float MoveX { get; private set; }
        public event UnityAction OnJumpPressed;
        public event UnityAction OnJumpReleased;
        public event UnityAction OnDashPressed;
        public event UnityAction OnPickUpPressed;
        public event UnityAction OnThrowPressed;
        public event UnityAction OnThrowReleased;

        private void OnEnable()
        {
            _controls = new Controls();
            _gamepad = Gamepad.current;
            _controls.Gameplay.SetCallbacks(this);

            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveX = context.ReadValue<Vector2>().x;
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    OnJumpPressed?.Invoke();
                    break;

                case InputActionPhase.Canceled:
                    OnJumpReleased?.Invoke();
                    break;
            }
        }

        public void OnDash(InputAction.CallbackContext context)
        {
            OnDashPressed?.Invoke();
        }

        public void OnPickUp(InputAction.CallbackContext context)
        {
            OnPickUpPressed?.Invoke();
        }

        public void OnAimToThrow(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    OnThrowPressed?.Invoke();
                    break;

                case InputActionPhase.Canceled:
                    OnThrowReleased?.Invoke();
                    break;
            }
        }
    }
}
