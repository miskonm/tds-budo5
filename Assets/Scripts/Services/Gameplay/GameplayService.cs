using TDS.Infrastructure.Locator;
using TDS.Infrastructure.State;
using TDS.Services.LevelManagement;
using TDS.Services.Mission;
using UnityEngine;

namespace TDS.Services.Gameplay
{
    public class GameplayService : IService
    {
        #region Variables

        private readonly LevelManagementService _levelManagementService;
        private readonly StateMachine _stateMachine;
        private readonly MissionGameService _missionGameService;

        #endregion

        #region Setup/Teardown

        public GameplayService(MissionGameService missionGameService, LevelManagementService levelManagementService,
            StateMachine stateMachine)
        {
            _missionGameService = missionGameService;
            _levelManagementService = levelManagementService;
            _stateMachine = stateMachine;
        }

        #endregion

        #region Public methods

        public void Dispose()
        {
            _missionGameService.OnCompleted -= OnMissionCompleted;
        }

        public void Initialize()
        {
            _missionGameService.OnCompleted += OnMissionCompleted;
        }

        private void OnMissionCompleted()
        {
            _levelManagementService.IncrementLevel();

            if (_levelManagementService.IsCurrentLevelExists())
            {
                _stateMachine.Enter<GameState>();
            }
            else
            {
                Debug.LogError($"OLOLOL! YOU WIN! ALL GAME FINISHED!");
            }
        }

        #endregion
    }
}