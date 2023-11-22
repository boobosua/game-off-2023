using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scaleton
{
    public class PlayerStateMachine : MonoBehaviour
    {
        [field: SerializeField] public PlayerController Input { get; private set; }

        private void OnEnable()
        {
            Input.OnJumpPressed += PlayerController_OnJumpPressed;
            Input.OnJumpReleased += PlayerController_OnJumpReleased;
        }

        private void PlayerController_OnJumpReleased()
        {
            Debug.Log("Jump Released!");
        }

        private void PlayerController_OnJumpPressed()
        {
            Debug.Log("Jump Pressed!");
        }
    }
}

