using UnityEngine;

namespace TDS.Game.Enemy
{
    public abstract class EnemyMovement : EnemyComponent
    {
        #region Variables

        [SerializeField] private EnemyAnimation _animation;

        #endregion

        #region Properties

        protected EnemyAnimation Animation => _animation;

        #endregion

        #region Public methods

        public abstract void SetTarget(Transform target);

        #endregion
    }
}