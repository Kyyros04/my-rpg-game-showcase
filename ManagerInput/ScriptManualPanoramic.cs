using UnityEngine;
using System.Collections;

namespace Intoworld2dtd
{
    /// <summary>
    /// Concrete execution runtime sample showing dynamic polymorphic swapping via safe Coroutine handlers.
    /// </summary>
    public class ScriptManualPanoramic : ScriptPanoramicViewInteractable
    {
        public float speedCamera=3f;
        public Transform bottomLeftBound;
        public Transform topRightBound;

        protected override void StartPanoramic()
        {
            ScriptManagerInput.Instance.SetController(new ClassControllerCameraPan(panoramicCam, speedCamera, bottomLeftBound, topRightBound));

            StartCoroutine(WaitForExitManualPan());
        }

        private IEnumerator WaitForExitManualPan()
        {
            yield return StartCoroutine(WaitForExitInput()); // it is a ScriptPanoramicViewInteractable method, waiting for exit input user from panoramic camera view mode.

            ScriptManagerInput.Instance.ResetToPlayerController();
        }
    }
}
