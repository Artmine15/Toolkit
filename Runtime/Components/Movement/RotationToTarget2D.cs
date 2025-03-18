using System;
using UnityEngine;
using Artmine15.Extensions;

namespace Artmine15.Toolkit.Components
{
    [AddComponentMenu("Packages/Artmine15/Toolkit/Movement and Rotation/Rotation To Target 2D")]
    public class RotationToTarget2D : MonoBehaviour
    {
        [SerializeField] private float _lerpTime;
        [SerializeField] private Vector2 _rotationOffset;
        [SerializeField] private RotationType _rotationType;
        private Vector2 _direction;
        private Quaternion _targetRotation;

        public void RotateObjectTo(Transform rotatableTransform, Transform target, RotationType overrideRotationType, float zRotationFactor = -90)
        {
            _direction = target.position - rotatableTransform.position + (Vector3)_rotationOffset;
            _targetRotation = transform.GetZAngleFromDirection(_direction, zRotationFactor);

            if (overrideRotationType == RotationType.UseDefault)
            {
                if (_rotationType == RotationType.UseDefault)
                    throw new Exception($"Rotation type must be selected on {name}");
            }
            else
            {
                _rotationType = overrideRotationType;
            }

            switch (_rotationType)
            {
                case RotationType.NoDelay:
                    rotatableTransform.rotation = _targetRotation;
                    break;
                case RotationType.Lerp:
                    rotatableTransform.rotation = Quaternion.Lerp(rotatableTransform.rotation, _targetRotation, _lerpTime * Time.deltaTime);
                    break;
            }
        }
    }
}
