using TriInspector;
using UnityEngine;

namespace Artmine15.Toolkit.Components
{
    [AddComponentMenu("Packages/Artmine15/Toolkit/Movement and Rotation/Follow Target")]
    public sealed class FollowTarget : MonoBehaviour, IFollower
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;

        [Space]
        [SerializeField] private UpdateMethod _updateMethod;
        [SerializeField] private MovementType _movementType;
        [SerializeField] private MovementAxisFlags _lockAxis;

        [ShowIf(nameof(_movementType), MovementType.Lerp)]
        [Space]
        [SerializeField, Range(0, 1)] private float _lerpTime;
        [ShowIf(nameof(_movementType), MovementType.MoveTowards)]
        [Space]
        [SerializeField] private float _moveDelta;

        private Vector3 _targetPosition;

        private void Update()
        {
            if (_updateMethod != UpdateMethod.Update) return;

            Move(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (_updateMethod != UpdateMethod.FixedUpdate) return;

            Move(Time.fixedDeltaTime);
        }

        private void LateUpdate()
        {
            if (_updateMethod != UpdateMethod.LateUpdate) return;

            Move(Time.deltaTime);
        }

        public void Move(float deltaTime)
        {
            _targetPosition = _target.position + _offset;

            if(_lockAxis.HasFlag(MovementAxisFlags.X) == true)
                _targetPosition.x = transform.position.x;
            if (_lockAxis.HasFlag(MovementAxisFlags.Y) == true)
                _targetPosition.y = transform.position.y;
            if (_lockAxis.HasFlag(MovementAxisFlags.Z) == true)
                _targetPosition.z = transform.position.z;

            switch (_movementType)
            {
                case MovementType.NoDelay:
                    transform.position = _targetPosition;
                    break;
                case MovementType.Lerp:
                    transform.position = Vector3.Lerp(transform.position, _targetPosition, _lerpTime);
                    break;
                case MovementType.MoveTowards:
                    transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveDelta * deltaTime);
                    break;
                default:
                    break;
            }
        }
    }
}
