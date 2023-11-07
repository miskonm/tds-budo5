namespace TDS.Infrastructure.State
{
    public interface IPayloadState<in T> : IExitableState
    {
        void Enter(T payload);
    }
}