using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyDeath : EnemyComponent
    {
        #region Variables

        [SerializeField] private UnitHp _hp;
        [SerializeField] private EnemyAnimation _animation;

        #endregion

        #region Events

        public event Action<EnemyDeath> OnHappened;

        #endregion

        #region Properties

        public bool IsDead { get; private set; }

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _hp.OnChanged += OnHpChanged;
        }

        private void Start()
        {
            OnHpChanged(_hp.Current);
        }

        private void OnDisable()
        {
            _hp.OnChanged -= OnHpChanged;
        }

        #endregion

        #region Private methods

        private void OnHpChanged(int currentHp)
        {
            if (IsDead || currentHp > 0)
            {
                return;
            }

            IsDead = true;
            _animation.PlayDeath();
            OnHappened?.Invoke(this);
        }

        #endregion
    }
}