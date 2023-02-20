using UnityEngine;
using Core.Player;
using UnityEngine.InputSystem;

namespace Core.Inputs
{
    public class PlayerInputs : GameInputs.IPlayerInputsActions
    {
        public Vector2 move;
        public Vector2 look;
        public bool pause;

        private PlayerInputCallbacks callbacks;
        private GameInputs gameInputs;

        #region Constructor
        public PlayerInputs(PlayerInputCallbacks callbacks, GameInputs gameInputs)
        {
            this.callbacks = callbacks;
            this.gameInputs = gameInputs;

            gameInputs.PlayerInputs.SetCallbacks(this);
        }
        #endregion

        #region Enable/Disable
        public void Enable()
        {
            gameInputs.PlayerInputs.Enable();
            // Cursor.lockState = CursorLockMode.Locked;
            // Cursor.visible = false;
        }

        public void Disable()
        {
            gameInputs.PlayerInputs.Disable();
            Cursor.lockState = CursorLockMode.None;
        }
        #endregion

        public void OnMove(InputAction.CallbackContext context)
        {
            move = context.ReadValue<Vector2>();
            callbacks.OnPlayerMove?.Invoke(move);
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            look = context.ReadValue<Vector2>();
            callbacks.OnPlayerLook?.Invoke(look);
        }


        public void OnPause(InputAction.CallbackContext context)
        {
            switch(context.phase)
            {
                case InputActionPhase.Performed:
                    //pause = true;
                    callbacks.OnPlayerPausePressed?.Invoke();
                    break;

                // case InputActionPhase.Canceled:
                //     pause = false;
                //     callbacks.OnPlayerPausePressed?.Invoke();
                //     break;
            }
        }
    }

}