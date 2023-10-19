using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyHpStagesAttack : EnemyAttack
    {
        #region Public Nested Types

        [Serializable]
        public class AttackStageInfo
        {
            #region Variables

            [HideInInspector]
            [SerializeField] private string _inspectorName;
            
            public EnemyAttack EnemyAttack;
            public int HpCount; // TODO: Change name for more understanding

            #endregion

            #region Public methods

            public void Validate()
            {
                _inspectorName = HpCount.ToString();
            }

            #endregion
        }

        #endregion

        #region Variables

        [Header("EnemyHpStagesAttack")]
        [SerializeField] private UnitHp _hp;
        [SerializeField] private List<AttackStageInfo> _stages;

        private EnemyAttack _currentAttack;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            SetCurrentAttack(_hp.Current);
        }

        private void OnEnable()
        {
            _hp.OnChanged += OnHpChanged;
        }

        private void OnDisable()
        {
            _hp.OnChanged -= OnHpChanged;
        }

        private void OnValidate()
        {
            if (_stages == null)
            {
                return;
            }

            foreach (AttackStageInfo info in _stages)
            {
                info.Validate();
            }
        }

        #endregion

        #region Private methods

        private void OnHpChanged(int hp)
        {
            SetCurrentAttack(hp);
        }

        private void SetCurrentAttack(int hp)
        {
            for (int i = _stages.Count - 1; i >= 0; i--)
            {
                AttackStageInfo info = _stages[i];
                if (hp <= info.HpCount)
                {
                    _currentAttack = info.EnemyAttack;
                    return;
                }
            }
        }

        #endregion
    }
}