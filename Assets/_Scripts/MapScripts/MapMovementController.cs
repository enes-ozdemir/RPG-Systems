using UnityEngine;

namespace _Scripts.MapScripts
{
    public class MapMovementController : MonoBehaviour
    {
        public float speed = 5f;
        private Vector3 _targetPosition;
        private bool _isMoving;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _targetPosition.z = transform.position.z; // Keep the original z position
                _isMoving = true;
            }
        }

        private void FixedUpdate()
        {
            if (!_isMoving) return;

            var direction = (_targetPosition - transform.position).normalized;
            var distance = Vector3.Distance(transform.position, _targetPosition);

            if (distance > 0.1f)
            {
                _rigidbody2D.velocity = direction * speed;
            }
            else
            {
                _rigidbody2D.velocity = Vector2.zero;
                _isMoving = false;
            }
        }
    }
}