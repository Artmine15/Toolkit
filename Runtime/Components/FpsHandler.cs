using TriInspector;
using UnityEngine;

namespace Artmine15.Utils.Toolkit.Components
{
    public class FpsHandler : MonoBehaviour
    {
        public enum FpsHandlerMode { Manual, ScreenRefreshRate }
        public enum FpsHandlerEncapsulation { ControlledByHandler, EditedByExternalClass }

        [DisableIf(nameof(_handlerEncapsulation), FpsHandlerEncapsulation.EditedByExternalClass)]
        [SerializeField] private FpsHandlerMode _handlerMode;
        private FpsHandlerEncapsulation _handlerEncapsulation;
        [DisableIf(nameof(_handlerEncapsulation), FpsHandlerEncapsulation.EditedByExternalClass)]
        [SerializeField, Range(-1, 999)] private int _defaultFps = 60;

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
                    SetDefaultTargetFps();
                    break;
                case FpsHandlerMode.ScreenRefreshRate:
                    SetRefreshRateBasedTargetFps();
                    break;
                default:
                    break;
            }
        }

        public void SetTargetFps(int fps)
        {
            Application.targetFrameRate = fps;
            _handlerEncapsulation = FpsHandlerEncapsulation.EditedByExternalClass;
        }

        private void SetDefaultTargetFps()
        {
            Application.targetFrameRate = _defaultFps;
            _handlerEncapsulation = FpsHandlerEncapsulation.ControlledByHandler;
        }

        private void SetRefreshRateBasedTargetFps()
        {
            Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;
            _handlerEncapsulation = FpsHandlerEncapsulation.ControlledByHandler;
        }

        public void ReturnControlToHandler()
        {
            _handlerEncapsulation = FpsHandlerEncapsulation.ControlledByHandler;
            UpdateTargetFps();
        }
    }
}
