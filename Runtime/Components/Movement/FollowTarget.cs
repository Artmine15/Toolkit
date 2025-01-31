using UnityEngine;

namespace Artmine15.Toolkit.Components
{
    [AddComponentMenu("Packages/Artmine15/Toolkit/Movement and Rotation/Follow Target")]
    public sealed class FollowTarget : Movement
    {
        [SerializeField] private Transform _target;
        [SerializeField] private MovementType _movementType;
        [SerializeField] private MovementAxisFlags _lockAxis;
        [SerializeField, Range(0, 1)] private float _lerpTime;

        [Space]
        [SerializeField] private bool _isRotateToTarget2D;

        private RotationToTarget2D _rotationToTarget2D;

        private void Awake()
        {
            if(TryGetComponent(out _rotationToTarget2D) == true)
            {
                _rotationToTarget2D.enabled = _isRotateToTarget2D;
            }
        }

        private void Update()
        {
            Move();
        }

        protected override void Move()
        {
            Vector3 targetPosition = _target.position;
            if(_lockAxis.HasFlag(MovementAxis.X) == true)
                targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);
            if (_lockAxis.HasFlag(MovementAxis.Y) == true)
                targetPosition = new Vector3(targetPosition.x, 0, targetPosition.z);
            if (_lockAxis.HasFlag(MovementAxis.Z) == true)
                targetPosition = new Vector3(targetPosition.x, targetPosition.y, 0);

            switch (_movementType)
            {
                case MovementType.NoDelay:
                    transform.position = targetPosition;
                    break;
                case MovementType.Lerp:
                    transform.position = Vector3.LerpUnclamped(transform.position, targetPosition, _lerpTime);
                    break;
                case MovementType.MoveTowards:
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, CurrentSpeed * Time.deltaTime);
                    break;
                default:
                    break;
            }

            if (_isRotateToTarget2D == true)
                _rotationToTarget2D.RotateObjectTo(transform, _target, RotationType.UseDefault);
        }
    }
}
