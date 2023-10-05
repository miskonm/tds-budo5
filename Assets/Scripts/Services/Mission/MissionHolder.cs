using UnityEngine;

namespace TDS.Services.Mission
{
    public class MissionHolder : MonoBehaviour
    {
        [SerializeField] private MissionCondition _missionCondition;
        
        public MissionCondition MissionCondition => _missionCondition;
    }
}