using UnityEngine;

namespace Artmine15.Packages.Utils.Toolkit.Code
{
    public abstract class Rotation : MonoBehaviour
    {
        [SerializeField] protected float LerpTime;
        [SerializeField] protected Vector2 RotationOffset;
        [SerializeField] protected RotationType RotationType;
        protected Vector2 Direction;
        protected Quaternion TargetRotation;
    }
}

