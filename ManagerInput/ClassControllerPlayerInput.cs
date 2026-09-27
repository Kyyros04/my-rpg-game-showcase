using UnityEngine;
using System;
namespace Intoworld2dtd
{
    public class ClassControllerPlayerInput : IControllerCmd
    {
        private ScriptPlayerController playerObj;
        private Vector2 direction;
        private bool isMoving;

        public ClassControllerPlayerInput()
        {
            SetPlayer();
        }

        private bool SetPlayer()
        {
            if (ScriptPlayerController.Instance == null) return false;

            var controller = ScriptPlayerController.Instance;
            if (controller == null)
            {
                Debug.LogError("ControllerPlayerInput: ScriptPlayerController component not found on player.");
                return false;
            }

            playerObj = controller;
            return true;
        }

        public void UpdateInput()
        {
            float h = InputsManager.Horizontal();
            float v = InputsManager.Vertical();

            direction = new Vector2(Convert.ToSingle(h), Convert.ToSingle(v));
            isMoving = direction.sqrMagnitude > 0;
        }

        public void UpdateView()
        {
            if(playerObj == null && !SetPlayer()) return;

            playerObj.dirMovement = !ScriptManagerState.IsBusy ? GetDirection() : Vector2.zero;
            playerObj.inMovement = !ScriptManagerState.IsBusy && IsMoving();
            
        }

        public Vector2 GetDirection() => direction;
        public bool IsMoving() => isMoving;
    }
}
