using UnityEngine;
using Core.Player;
using UnityEngine.InputSystem;

namespace Core.Inputs
{
    public class PauseInputs : GameInputs.IPauseInputsActions
    {
        public bool returnPressed;

        private PlayerInputCallbacks callbacks;
        private GameInputs gameInputs;

        #region Constructor
        public PauseInputs(PlayerInputCallbacks callbacks, GameInputs gameInputs)
        {
            this.callbacks = callbacks;
            this.gameInputs = gameInputs;

            gameInputs.PauseInputs.SetCallbacks(this);
        }
        #endregion

        #region Enable/Disable
        public void Enable()
        {
            gameInputs.PauseInputs.Enable();
            Cursor.lockState = CursorLockMode.None;
        }

        public void Disable()
        {
            gameInputs.PauseInputs.Disable();
            //Cursor.lockState = CursorLockMode.Locked;
        }
        #endregion

        public void OnReturn(InputAction.CallbackContext context)
        {
            switch(context.phase)
            {
                case InputActionPhase.Performed:
                    callbacks.OnPlayerReturnPressed?.Invoke();
                    break;
            }
        }
    }
}
