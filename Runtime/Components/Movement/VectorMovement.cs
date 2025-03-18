using UnityEngine;

namespace Artmine15.Toolkit.Components
{
    [AddComponentMenu("Packages/Artmine15/Toolkit/Movement and Rotation/Vector Movement")]
    public class VectorMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        protected Vector3 Vector;

        private void Update()
        {
            Move();
        }

        public void Move()
        {
            transform.position += Vector * _speed * Time.deltaTime;
        }
    }
}
