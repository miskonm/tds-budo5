using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyDirectMovement : EnemyMovement
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 3f;

        private Transform _target;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_target == null)
            {
                return;
            }

            MoveToTarget();
        }

        private void OnDisable()
        {
            _rb.velocity = Vector2.zero;
            Animation.SetSpeed(0);
        }

        #endregion

        #region Public methods

        public override void SetTarget(Transform target)
        {
            _target = target;

            if (_target == null)
            {
                Animation.SetSpeed(0);
                _rb.velocity = Vector2.zero;
            }
        }

        #endregion

        #region Private methods

        private void MoveToTarget()
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            _rb.velocity = direction * +_speed;
            transform.up = direction;
            Animation.SetSpeed(_speed);
        }

        #endregion
    }
}