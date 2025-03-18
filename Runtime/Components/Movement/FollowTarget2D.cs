using System;
using TriInspector;
using UnityEngine;

namespace Artmine15.Toolkit.Components
{
    [AddComponentMenu("Packages/Artmine15/Toolkit/Movement and Rotation/Follow Target 2D")]
    public class FollowTarget2D : MonoBehaviour, IFollower
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector2 _offset;

        [Space]
        [SerializeField] private UpdateMethod _updateMethod;
        [SerializeField] private MovementType _movementType;
        [SerializeField] private MovementAxisFlags2D _lockAxis;

        [ShowIf(nameof(_movementType), MovementType.Lerp)]
        [Space]
        [SerializeField, Range(0, 1)] private float _lerpTime;
        [ShowIf(nameof(_movementType), MovementType.MoveTowards)]
        [Space]
        [SerializeField] private float _moveDelta;

        [Space]
        [SerializeField] private bool _isRotateToTarget2D;

        private RotationToTarget2D _rotationToTarget2D;

        private Vector2 _targetPosition;

        private void Awake()
        {
            if (TryGetComponent(out _rotationToTarget2D) == true)
            {
                _rotationToTarget2D.enabled = _isRotateToTarget2D;
            }
        }

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
            _targetPosition = (Vector2)_target.position + _offset;

            if (_lockAxis.HasFlag(MovementAxisFlags2D.X) == true)
                _targetPosition.x = transform.position.x;
            if (_lockAxis.HasFlag(MovementAxisFlags2D.Y) == true)
                _targetPosition.y = transform.position.y;

            switch (_movementType)
            {
                case MovementType.NoDelay:
                    transform.position = _targetPosition;
                    break;
                case MovementType.Lerp:
                    transform.position = Vector2.Lerp(transform.position, _targetPosition, _lerpTime);
                    break;
                case MovementType.MoveTowards:
                    transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _moveDelta * deltaTime);
                    break;
                default:
                    break;
            }

            if (_isRotateToTarget2D == true)
            {
                if (_rotationToTarget2D != null)
                    _rotationToTarget2D.RotateObjectTo(transform, _target, RotationType.UseDefault);
                else
                    throw new NullReferenceException();
            }
        }
    }
}
