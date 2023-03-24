
namespace statemachine
{

    /// <summary>
    /// A simple state maching
    /// </summary>
    public class StateMachine
    {
        // the states
        public State wanderState;
        public State recoverState;

        private State currentState;

        public StateMachine(Agent owner)
        {
            wanderState = new WanderState(owner, this);
            recoverState = new RecoverState(owner, this);
            SwitchState(wanderState);
        }

        /// <summary>
        /// Switch from one state to another
        /// </summary>
        /// <param name="newState">The new state to be</param>
        public void SwitchState(State newState)
        {
            currentState?.ExitState();
            currentState = newState;
            currentState.EnterState();
        }

        /// <summary>
        /// Update the current state (let it do its thing)
        /// </summary>
        public void UpdateState()
        {
            currentState.UpdateState(); 
        }
    }
}