using TDS.Infrastructure.Locator;
using TDS.Services.SceneLoading;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class BootstrapState : IState
    {
        public void Exit()
        {
            Debug.LogError($"BootstrapState Exit");
        }

        public void Enter()
        {
           Debug.LogError($"BootstrapState Enter");

           ServiceLocator.Instance.Register(new SceneLoadingService());
           
           StateMachine stateMachine = ServiceLocator.Instance.Get<StateMachine>();
           stateMachine.Enter<MenuState>();
        }
    }
}