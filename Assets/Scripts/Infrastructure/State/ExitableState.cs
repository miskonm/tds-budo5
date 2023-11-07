using TDS.Infrastructure.Locator;

namespace TDS.Infrastructure.State
{
    public abstract class ExitableState : IExitableState
    {
        #region Properties

        protected ServiceLocator ServiceLocator { get; }
        protected StateMachine StateMachine => ServiceLocator.Get<StateMachine>();

        #endregion

        #region Setup/Teardown

        protected ExitableState(ServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
        }

        #endregion

        #region IExitableState

        public abstract void Exit();

        #endregion
    }
}