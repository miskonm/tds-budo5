using TDS.Infrastructure.Locator;
using TDS.Services.SceneLoading;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class MenuState : IState
    {
        public void Exit()
        {
            Debug.LogError($"MenuState Exit");
        }

        public void Enter()
        {
            Debug.LogError($"MenuState Enter");

            SceneLoadingService sceneLoadingService = ServiceLocator.Instance.Get<SceneLoadingService>();
            sceneLoadingService.LoadScene(Scene.Menu);
            
            
        }
    }
}