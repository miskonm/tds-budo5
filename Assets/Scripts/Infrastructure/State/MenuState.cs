using TDS.Infrastructure.Locator;
using TDS.Services.SceneLoading;
using UnityEngine;

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
            Debug.LogError("MenuState Enter");

            ServiceLocator.Get<SceneLoadingService>().LoadScene(Scene.Menu);
        }

        public override void Exit()
        {
            Debug.LogError("MenuState Exit");
        }

        #endregion
    }
}