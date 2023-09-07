using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Dead = Animator.StringToHash("Dead");
        private static readonly int Speed = Animator.StringToHash("Speed");

        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void PlayAttack()
        {
            _animator.SetTrigger(Attack);
        }

        public void PlayDeath()
        {
            _animator.SetTrigger(Dead);
        }

        public void SetSpeed(float value)
        {
            _animator.SetFloat(Speed, value);
        }

        #endregion
    }
}