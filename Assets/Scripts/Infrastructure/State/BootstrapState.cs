using TDS.Infrastructure.Locator;
using TDS.Services.Coroutine;
using TDS.Services.Mission;
using TDS.Services.SceneLoading;
using UnityEngine;

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
            Debug.LogError("BootstrapState Enter");

            ServiceLocator.Register(new SceneLoadingService());
            ServiceLocator.Register(new MissionGameService());
            ServiceLocator.RegisterMonoBeh<CoroutineRunner>();

            StateMachine.Enter<MenuState>();
        }

        public override void Exit()
        {
            Debug.LogError("BootstrapState Exit");
        }

        #endregion
    }
}