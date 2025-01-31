using TriInspector;
using UnityEngine;

namespace Artmine15.Toolkit.Components
{
    [AddComponentMenu("Packages/Artmine15/Toolkit/Fps Handler")]
    public class FpsHandler : MonoBehaviour
    {
        private const int _maxFps = 999;

        [HideIf(nameof(_handlerEncapsulation), FpsHandlerEncapsulation.EditedByExternalClass)]
        [SerializeField] private FpsHandlerMode _handlerMode;
        private FpsHandlerEncapsulation _handlerEncapsulation;

        [HideIf(nameof(_handlerEncapsulation), FpsHandlerEncapsulation.EditedByExternalClass)]
        [HideIf(nameof(_handlerMode), FpsHandlerMode.ScreenRefreshRate)]
        [HideIf(nameof(_handlerMode), FpsHandlerMode.Maximum)]
        [SerializeField, Range(-1, _maxFps)] private int _defaultFps = 60;
        [ReadOnly]
        [SerializeField] private int _currentFps;

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
            if (_handlerEncapsulation == FpsHandlerEncapsulation.EditedByExternalClass) return;

            switch (_handlerMode)
            {
                case FpsHandlerMode.Manual:
                    SetTargetFpsFromHandler(_defaultFps);
                    break;
                case FpsHandlerMode.ScreenRefreshRate:
                    SetTargetFpsFromHandler((int)Screen.currentResolution.refreshRateRatio.value);
                    break;
                case FpsHandlerMode.Maximum:
                    SetTargetFpsFromHandler(_maxFps);
                    break;
                default:
                    break;
            }
        }

        public void SetTargetFps(int fps)
        {
            _currentFps = fps;
            Application.targetFrameRate = _currentFps;
            _handlerEncapsulation = FpsHandlerEncapsulation.EditedByExternalClass;
        }

        private void SetTargetFpsFromHandler(int fps)
        {
            _currentFps = fps;
            Application.targetFrameRate = _currentFps;
            _handlerEncapsulation = FpsHandlerEncapsulation.ControlledByHandler;
        }

        public void ReturnControlToHandler()
        {
            _handlerEncapsulation = FpsHandlerEncapsulation.ControlledByHandler;
            UpdateTargetFps();
        }
    }
}
