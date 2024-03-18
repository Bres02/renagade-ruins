using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static PlayerInputActions;

namespace RenegadeRuins {

    [CreateAssetMenu(fileName = "InputReader", menuName = "RenegadeRuins/InputReader")]
    public class InputReader : ScriptableObject, PlayerInputActions.IPlayerActions
    {
        public event UnityAction<Vector2> Move = delegate { };
        public event UnityAction<Vector2, bool> Look = delegate { };
        public event UnityAction EnableMouseControlCamera = delegate { };
        public event UnityAction DisableMouseControlCamera = delegate { };

        PlayerInputActions inputActions;

        void onEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerInputActions();
                inputActions.Player.SetCallbacks(this);
            }
            inputActions.Enable();
        }

        public Vector3 Direction => inputActions.Player.Move.ReadValue<Vector2>();


        public void OnMove(InputAction.CallbackContext context)
        {
            Move.Invoke(context.ReadValue<Vector2>());
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            Look.Invoke(context.ReadValue<Vector2>(), IsDeviceMouse(context));
        }

        bool IsDeviceMouse(InputAction.CallbackContext context)
        {
            return context.control.device.name == "Mouse";
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            // Nothing
        }

        public void OnMouseControlCamera(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    EnableMouseControlCamera.Invoke();
                    break;
                case InputActionPhase.Canceled:
                    DisableMouseControlCamera.Invoke();
                    break;
            }
        }

        public void OnRun(InputAction.CallbackContext context)
        {
            // Nothing
        }

        public void OnDodge(InputAction.CallbackContext context)
        {
            // Nothing
        }

        public void OnMelee(InputAction.CallbackContext context)
        {
            // Nothing
        }

        public void OnSpecial(InputAction.CallbackContext context)
        {
            // Nothing
        }
    }

}
