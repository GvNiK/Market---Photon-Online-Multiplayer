using UnityEngine;
using Core.Inputs;

namespace Core.Player
{
    public class PlayerInputBroadcaster : MonoBehaviour
    {
       private PlayerInputCallbacks callbacks;
       private GameInputs gameInputs;
       private PlayerInputs playerInputs;
       private PauseInputs pauseInputs;

        #region Constructor
        public PlayerInputBroadcaster()
        {
            callbacks = new PlayerInputCallbacks();
            gameInputs = new GameInputs();
            
            playerInputs = new PlayerInputs(callbacks, gameInputs);
            pauseInputs = new PauseInputs(callbacks, gameInputs);

            EnableAction(ControlType.Player);
        }
        #endregion

        public void Destroy()
        {
            gameInputs.Dispose();
        }

        public void EnableAction(ControlType type)
        {
            DisableActions();

            switch(type)
            {
                case ControlType.Player:
                    playerInputs.Enable();
                    break;

                case ControlType.Pause:
                    pauseInputs.Enable();
                    break;

                case ControlType.None:
                    break;
            }
        }

        private void DisableActions()
        {
            playerInputs.Disable();
            pauseInputs.Disable();
        }

        #region Getter/Setter
        public PlayerInputCallbacks Callbacks
        {
            get
            {
                return callbacks;
            }
        }

        public PlayerInputs PlayerInputs
        {
            get
            {
                return playerInputs;
            }
        }
        #endregion
    }

    public enum ControlType
    {
        Player,
        Pause,
        None
    }
}
