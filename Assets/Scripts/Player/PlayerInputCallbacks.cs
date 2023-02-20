using System;
using UnityEngine;

namespace Core.Player
{
    public class PlayerInputCallbacks
    {
        public Action<Vector2> OnPlayerMove;
        public Action<Vector2> OnPlayerLook;
        public Action OnPlayerPausePressed;
        public Action OnPlayerReturnPressed;
    }
}
