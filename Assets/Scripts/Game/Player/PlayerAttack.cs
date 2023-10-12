using Lean.Pool;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;

        [Header("Settings")]
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPositionTransform;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }
        }

        #endregion

        #region Private methods

        private void CreateBullet()
        {
            LeanPool.Spawn(_bulletPrefab, _bulletSpawnPositionTransform.position, transform.rotation);
        }

        private void Fire()
        {
            _animation.PlayAttack();
            CreateBullet();
        }

        #endregion
    }
}