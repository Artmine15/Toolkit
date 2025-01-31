using Artmine15.Toolkit;
using UnityEngine;

namespace Artmine15.Toolkit.Components
{
    [AddComponentMenu("Packages/Artmine15/Toolkit/Movement and Rotation/Vector Movement")]
    public class VectorMovement : Movement
    {
        protected Vector3 Vector;

        private void Update()
        {
            Move();
        }

        protected override void Move()
        {
            transform.position += Vector * CurrentSpeed * Time.deltaTime;
        }
    }
}
