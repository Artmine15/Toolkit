using UnityEngine;

namespace Artmine15.Utils.Toolkit.Components.Debug
{
    public class TimeScaleHandler : MonoBehaviour
    {
        [SerializeField, Range(0, 5)] private float _timeScale;

        private void OnValidate()
        {
            Time.timeScale = _timeScale;
        }
    }
}
