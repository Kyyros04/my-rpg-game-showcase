using UnityEngine;

namespace Intoworld2dtd
{
    /// <summary>
    /// Null-Object variant pattern forcing hardcoded vector operations while muting physical hardware polling.
    /// </summary>
    public class ClassControllerBlocker : IControllerCmd
    {
        private ScriptPlayerController playerObj;
        private Vector2 direction;

        public ClassControllerBlocker(ScriptPlayerController playerObj, Vector2 direction)
        {
            this.playerObj = playerObj;
            this.direction = direction;
        }
        public Vector2 GetDirection() => direction;

        public bool IsMoving() => true;

        public void UpdateInput()
        {
            ;
        }
        public void UpdateView()
        {
            playerObj.dirMovement = GetDirection();
            playerObj.inMovement = IsMoving();
        }
    }
}