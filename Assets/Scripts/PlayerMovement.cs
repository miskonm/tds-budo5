using UnityEngine;

namespace TDS
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _speed = 5f;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            Rotate();
            Move();
        }

        #endregion

        #region Private methods

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 currentPosition = transform.position;
            currentPosition.x += horizontal * _speed * Time.deltaTime;
            currentPosition.y += vertical * _speed * Time.deltaTime;
            transform.position = currentPosition;
        }

        private void Rotate()
        {
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldMousePosition.z = 0;
            Vector3 direction = worldMousePosition - transform.position;
            transform.up = direction;
        }

        #endregion
    }
}