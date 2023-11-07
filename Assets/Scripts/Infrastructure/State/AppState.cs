using TDS.Infrastructure.Locator;

namespace TDS.Infrastructure.State
{
    public abstract class AppState : ExitableState, IState
    {
        #region Setup/Teardown

        protected AppState(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region IState

        public abstract void Enter();

        #endregion
    }

    public abstract class AppState<T> : ExitableState, IPayloadState<T>
    {
        #region Setup/Teardown

        protected AppState(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region IPayloadState<T>

        public abstract void Enter(T payload);

        #endregion
    }
}