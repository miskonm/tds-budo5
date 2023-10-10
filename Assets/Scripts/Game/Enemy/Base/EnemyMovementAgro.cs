using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMovementAgro : EnemyComponent
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyIdle _idle;
        [SerializeField] private LayerMask _obstacleMask;

        private bool _isFollow;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _triggerObserver.OnExit += OnObserverExit;
            _triggerObserver.OnStay += OnObserverStay;
        }

        private void OnDisable()
        {
            _triggerObserver.OnExit -= OnObserverExit;
            _triggerObserver.OnStay -= OnObserverStay;
        }

        #endregion

        #region Private methods

        private void OnObserverExit(Collider2D other)
        {
            _isFollow = false;
            SetTarget(null);
        }

        private void OnObserverStay(Collider2D other)
        {
            if (_isFollow)
            {
                return;
            }

            Vector3 direction = other.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, direction.magnitude, _obstacleMask);
            if (hit.transform != null)
            {
                return;
            }

            _isFollow = true;
            SetTarget(other.transform);
        }

        private void SetTarget(Transform otherTransform)
        {
            if (_enemyMovement != null)
            {
                _enemyMovement.SetTarget(otherTransform);
            }

            if (_idle != null)
            {
                if (otherTransform == null)
                {
                    _idle.Activate();
                }
                else
                {
                    _idle.Deactivate();
                }
            }
        }

        #endregion
    }
}