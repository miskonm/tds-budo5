using Lean.Pool;
using TDS.Services.Input;
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

        private IInputService _inputService;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            if (_inputService != null)
            {
                _inputService.OnAttack += Fire;
            }
        }

        private void OnDisable()
        {
            _inputService.OnAttack -= Fire;
        }

        #endregion

        #region Public methods

        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.OnAttack += Fire;
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