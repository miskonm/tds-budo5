using TDS.Infrastructure.Locator;
using TDS.Services.Coroutine;
using TDS.Services.Gameplay;
using TDS.Services.LevelManagement;
using TDS.Services.Mission;
using TDS.Services.SceneLoading;

namespace TDS.Infrastructure.State
{
    public class BootstrapState : AppState
    {
        #region Setup/Teardown

        public BootstrapState(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region Public methods

        public override void Enter()
        {
            SceneLoadingService sceneLoadingService = new();
            ServiceLocator.Register(sceneLoadingService);
            MissionGameService missionGameService = new();
            ServiceLocator.Register(missionGameService);
            LevelManagementService levelManagementService = new(sceneLoadingService);
            ServiceLocator.Register(levelManagementService);
            ServiceLocator.RegisterMonoBeh<CoroutineRunner>();
            ServiceLocator.Register(new GameplayService(missionGameService, levelManagementService, StateMachine));

            StateMachine.Enter<MenuState>();
        }

        public override void Exit() { }

        #endregion
    }
}