using UnityEngine;

namespace TDS.Services.Mission
{
    public class MissionFactory
    {
        #region Public methods

        public BaseMission Create(MissionCondition condition)
        {
            if (condition is KillSpecificEnemyMissionCondition specificEnemyMissionCondition)
            {
                KillSpecificEnemyMission mission = new();
                mission.SetCondition(specificEnemyMissionCondition);
                return mission;
            }

            if (condition is ReachDestinationMissionCondition reachDestinationMissionCondition)
            {
                ReachDestinationMission mission = new();
                mission.SetCondition(reachDestinationMissionCondition);
                return mission;
            }
            
            if (condition is KillAllEnemiesMissionCondition killAllEnemiesMissionCondition)
            {
                KillAllEnemiesMission mission = new();
                mission.SetCondition(killAllEnemiesMissionCondition);
                return mission;
            }

            Debug.LogError($"No mission for conditions '{condition.GetType().Name}'");

            return null;
        }

        #endregion
    }
}