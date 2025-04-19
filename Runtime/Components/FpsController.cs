using TriInspector;
using UnityEngine;

namespace Artmine15.Toolkit.Components
{
    [AddComponentMenu("Packages/Artmine15/Toolkit/Fps Controller")]
    public class FpsController : MonoBehaviour
    {
        private const int _maxFps = 999;

        [HideIf(nameof(_handlerEncapsulation), FpsHandlerEncapsulation.EditedByExternalClass)]
        [SerializeField] private FpsControllerMode _handlerMode = FpsControllerMode.ScreenRefreshRate;
        private FpsHandlerEncapsulation _handlerEncapsulation;

        [HideIf(nameof(_handlerEncapsulation), FpsHandlerEncapsulation.EditedByExternalClass)]
        [HideIf(nameof(_handlerMode), FpsControllerMode.ScreenRefreshRate)]
        [HideIf(nameof(_handlerMode), FpsControllerMode.Maximum)]
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
                case FpsControllerMode.Manual:
                    SetTargetFpsFromHandler(_defaultFps);
                    break;
                case FpsControllerMode.ScreenRefreshRate:
                    SetTargetFpsFromHandler((int)Screen.currentResolution.refreshRateRatio.value);
                    break;
                case FpsControllerMode.Maximum:
                    SetTargetFpsFromHandler(-1);
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