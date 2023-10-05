using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Services.Mission
{
    public class KillSpecificEnemyMissionCondition : MissionCondition
    {
        #region Variables

        [SerializeField] private EnemyDeath _enemyDeath;

        #endregion

        #region Properties

        public EnemyDeath EnemyDeath => _enemyDeath;

        #endregion
    }
}