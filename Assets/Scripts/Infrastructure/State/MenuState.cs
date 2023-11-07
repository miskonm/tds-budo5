using TDS.Infrastructure.Locator;
using TDS.Services.SceneLoading;

namespace TDS.Infrastructure.State
{
    public class MenuState : AppState
    {
        #region Setup/Teardown

        public MenuState(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region Public methods

        public override void Enter()
        {
            ServiceLocator.Get<SceneLoadingService>().LoadScene(Scene.Menu);
        }

        public override void Exit()
        {
            StateMachine.Enter<InitState, SceneType>(SceneType.Game);
        }

        #endregion
    }
}