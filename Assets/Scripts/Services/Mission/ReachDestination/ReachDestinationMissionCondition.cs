using TDS.Game;
using UnityEngine;

namespace TDS.Services.Mission
{
    public class ReachDestinationMissionCondition : MissionCondition
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;

        #endregion

        #region Properties

        public TriggerObserver TriggerObserver => _triggerObserver;

        #endregion
    }
}