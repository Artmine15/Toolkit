using UnityEngine;

namespace Artmine15.Toolkit.Components
{
    [AddComponentMenu("Packages/Artmine15/Toolkit/Time Scale Controller")]
    public class TimeScaleController : MonoBehaviour
    {
        [SerializeField, Range(0, 5)] private float _timeScale;

        private void OnValidate()
        {
            Time.timeScale = _timeScale;
        }
    }
}
