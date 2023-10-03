using System;
using TDS.Infrastructure.Locator;

namespace TDS.Infrastructure.State
{
    public class StateMachine : IService
    {
        #region Variables

        private IExitableState _currentState;

        #endregion

        #region Public methods

        public void Enter<T>() where T : IState
        {
            _currentState?.Exit();
            T newState = Create<T>();
            _currentState = newState;
            newState.Enter();
        }

        #endregion

        #region Private methods

        private T Create<T>() where T : IExitableState
        {
            return Activator.CreateInstance<T>();
        }

        #endregion
    }
}