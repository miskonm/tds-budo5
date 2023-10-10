using TDS.Infrastructure.Locator;
using TDS.Services.Coroutine;
using TDS.Services.Gameplay;
using TDS.Services.LevelManagement;
using TDS.Services.Mission;
using TDS.Services.SceneLoading;
using TDS.Utility;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class GameState : AppState
    {
        #region Setup/Teardown

        public GameState(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region Public methods

        public override void Enter()
        {
            LevelManagementService levelManagementService = ServiceLocator.Get<LevelManagementService>();
            levelManagementService.Initialize(); // TODO: Nikita maybe move it to bootstrap state
            levelManagementService.LoadCurrentLevel();

            ServiceLocator.Get<CoroutineRunner>().StartFrameTimer(1, InitAfterLoadScene);
        }

        public override void Exit()
        {
            ServiceLocator.Get<MissionGameService>().Dispose();
            ServiceLocator.Get<GameplayService>().Dispose();
        }

        #endregion

        #region Private methods

        private void InitAfterLoadScene()
        {
            ServiceLocator.Get<MissionGameService>().Initialize();
            ServiceLocator.Get<GameplayService>().Initialize();
        }

        #endregion
    }
}