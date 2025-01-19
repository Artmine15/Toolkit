using System;
using UnityEngine;
using Artmine15.Packages.Utils.Toolkit.Code;
using Artmine15.Packages.Utils.Extensions;

namespace Artmine15.Packages.Utils.Toolkit.Components
{
    [AddComponentMenu("Packages/Artmine15/Toolkit/Movement and Rotation/Rotation To Target 2D")]
    public class RotationToTarget2D : Rotation
    {
        public void RotateObjectTo(Transform objectTransform, Transform target, RotationType overrideRotationType, float zRotationFactor = -90)
        {
            Direction = target.position - objectTransform.position + (Vector3)RotationOffset;
            TargetRotation = transform.GetZAngleFromDirection(Direction, zRotationFactor);

            if (overrideRotationType == RotationType.UseDefault)
            {
                if (RotationType == RotationType.UseDefault)
                    throw new Exception($"Rotation type must be selected on {name}");
            }
            else
            {
                RotationType = overrideRotationType;
            }

            switch (RotationType)
            {
                case RotationType.NoDelay:
                    objectTransform.rotation = TargetRotation;
                    break;
                case RotationType.Lerp:
                    objectTransform.rotation = Quaternion.Lerp(objectTransform.rotation, TargetRotation, LerpTime * Time.deltaTime);
                    break;
            }
        }
    }
}
