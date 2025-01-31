using UnityEngine;

namespace Artmine15.Toolkit
{
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] private float _defaultSpeed;
        protected float CurrentSpeed;
        public bool IsMoving { get; protected set; }

        protected abstract void Move();

        public void ResetToDefaultSpeed()
        {
            CurrentSpeed = _defaultSpeed;
        }

        public float GetDefaultSpeed()
        {
            return _defaultSpeed;
        }
    }
}
