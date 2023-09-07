using UnityEngine;

namespace TDS
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _bulletPrefab;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                CreateBullet();
            }
        }

        #endregion

        #region Private methods

        private void CreateBullet()
        {
            Instantiate(_bulletPrefab, transform.position, transform.rotation);
        }

        #endregion
    }
}