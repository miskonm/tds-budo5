using System;
using TDS.Infrastructure.Locator;

namespace TDS.Infrastructure.State
{
    public class InitState : AppState<SceneType>
    {
        #region Setup/Teardown

        public InitState(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region Public methods

        public override void Enter(SceneType payload)
        {
            switch (payload)
            {
                case SceneType.Menu:
                    StateMachine.Enter<MenuState>();
                    break;
                case SceneType.Game:
                    StateMachine.Enter<GameState>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(payload), payload, null);
            }
        }

        public override void Exit() { }

        #endregion
    }

    public enum SceneType
    {
        Menu = 0,
        Game = 1,
    }
}