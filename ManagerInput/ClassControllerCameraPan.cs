using UnityEngine;

namespace Intoworld2dtd
{
     /// <summary>
    /// Concrete rendering controller containing pixel-snapping algorithms for dynamic camera scrolling.
    /// </summary>
    public class ClassControllerCameraPan : IControllerCmd
    {
        private Vector2 direction;
        private bool isMoving;

        private Transform cameraTransform;
        private float speed;
        private Transform bottomLeftBound;
        private Transform topRightBound;
        private float pixelSnap;

        public ClassControllerCameraPan(Transform cameraTransform, float speed, Transform bottomLeftBound, Transform topRightBound, float pixelSnap = 1f / 16f)
        {
            this.cameraTransform = cameraTransform;
            this.speed = speed;
            this.bottomLeftBound = bottomLeftBound;
            this.topRightBound = topRightBound;
            this.pixelSnap = pixelSnap;
        }

        public void UpdateInput()
        {
            float h = InputsManager.D_Key() ? 1 : InputsManager.A_Key() ? -1 : 0;
            float v = InputsManager.W_Key() ? 1 : InputsManager.S_Key() ? -1 : 0;

            direction = new Vector2(h, v).normalized;
            isMoving = direction.sqrMagnitude > 0;
        }

        public void UpdateView()
        {
            if (!isMoving || cameraTransform == null) return;
            Vector3 move = (Vector3)direction * speed * Time.deltaTime;

            Debug.Log("aggiorno view: " + move);
            Vector3 newPos = cameraTransform.position + move;

            newPos.x = Mathf.Round(newPos.x / pixelSnap) * pixelSnap;
            newPos.y = Mathf.Round(newPos.y / pixelSnap) * pixelSnap;

            var finalPosition = new Vector3(newPos.x, newPos.y, cameraTransform.position.z);

            if (bottomLeftBound.position.x < finalPosition.x
                && finalPosition.x < topRightBound.position.x
                && bottomLeftBound.position.y < finalPosition.y
                && finalPosition.y < topRightBound.position.y)
            {
                cameraTransform.position = finalPosition;
            }
        }

        public Vector2 GetDirection() => direction;
        public bool IsMoving() => isMoving;
    }
}
