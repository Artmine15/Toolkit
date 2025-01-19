using UnityEngine;

namespace Artmine15.Packages.Utils.Toolkit.Components.Debug
{
    [AddComponentMenu("Packages/Artmine15/Toolkit/Time Scale Handler")]
    public class TimeScaleHandler : MonoBehaviour
    {
        [SerializeField, Range(0, 5)] private float _timeScale;

        private void OnValidate()
        {
            Time.timeScale = _timeScale;
        }
    }
}
