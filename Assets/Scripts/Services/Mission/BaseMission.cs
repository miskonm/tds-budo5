using System;

namespace TDS.Services.Mission
{
    public abstract class BaseMission
    {
        #region Events

        public event Action OnCompleted;

        #endregion

        #region Public methods

        public abstract void Dispose();
        public abstract void Initialize();

        #endregion

        #region Protected methods

        protected void InvokeCompletion()
        {
            OnCompleted?.Invoke();
        }

        #endregion
    }

    public abstract class BaseMission<T> : BaseMission where T : MissionCondition
    {
        #region Properties

        protected T Condition { get; private set; }

        #endregion

        #region Public methods

        public sealed override void Dispose()
        {
            OnDispose();
            Condition = null;
        }

        public sealed override void Initialize()
        {
            OnInitialize();
        }

        public void SetCondition(T value)
        {
            Condition = value;
        }

        #endregion

        #region Protected methods

        protected virtual void OnDispose() { }
        protected virtual void OnInitialize() { }

        #endregion
    }
}