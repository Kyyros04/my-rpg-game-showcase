using UnityEngine;
using System.Collections;

namespace Intoworld2dtd
{
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
            yield return StartCoroutine(WaitForExitInput());

            ScriptManagerInput.Instance.ResetToPlayerController();
        }
    }
}
