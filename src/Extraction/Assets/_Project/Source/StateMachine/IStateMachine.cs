namespace Source.StateMachine
{
    public interface IStateMachine
    {
        IState CurrentState { get; }
        void SwitchState<TState>() where TState : class, IState;
    }
}
