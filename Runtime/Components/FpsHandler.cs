using UnityEngine;

namespace Artmine15.Utils.Toolkit.Components
{
    public class FpsHandler : MonoBehaviour
    {
        [SerializeField] private bool _refreshRateFps;
        [SerializeField, Range(-1, 999)] private int _fps = 60;

        private void Awake()
        {
            UpdateTargetFps();
        }

        private void OnValidate()
        {
            UpdateTargetFps();
        }

        private void UpdateTargetFps()
        {
            if (_refreshRateFps == true)
            {
                _fps = (int)Screen.currentResolution.refreshRateRatio.value;
                Application.targetFrameRate = _fps;
            }
            else
            {
                Application.targetFrameRate = _fps;
            }
        }
    }
}
