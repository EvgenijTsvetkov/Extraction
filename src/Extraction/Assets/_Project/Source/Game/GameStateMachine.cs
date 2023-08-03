using Source.StateMachine;

namespace Source.Game
{
    public class GameStateMachine : BaseStateMachine, IGame
    {
        public GameStateMachine(IState[] states)
        {
            foreach (var state in states) 
                AddState(state);
        }
    }
}
