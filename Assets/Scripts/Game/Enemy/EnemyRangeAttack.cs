using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyRangeAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(EnemyRangeAttack))]
        [SerializeField] private Bullet _bulletPrefab;

        private Transform _playerTransform;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _playerTransform = GameObject.FindWithTag(Tag.Player).transform;
        }

        #endregion

        #region Protected methods

        protected override void OnPerformAttack()
        {
            base.OnPerformAttack();

            Vector3 direction = _playerTransform.position - transform.position;
            Instantiate(_bulletPrefab, transform.position, Quaternion.Euler(direction));
        }

        #endregion
    }
}