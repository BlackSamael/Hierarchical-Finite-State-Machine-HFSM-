public class HFSMStateMachine
{
    private HFSMState currentState;
    public HFSMState IdleState;
    public HFSMState WalkState;
    public HFSMState JumpState;
    public HFSMState AttackState;
    public HFSMState CurrentState => currentState;

    public void SetInitialState(HFSMState state)
    {
        currentState = state;
        currentState.Enter();
    }

    public void Tick()
    {
        if (currentState == null)
            return;

        HFSMState transition = currentState.CheckTransitions();

        if (transition != null)
        {
            ChangeState(transition);
        }

        currentState.Tick();
    }

    public void ChangeState(HFSMState newState)
    {
        if (newState == currentState)
            return;

        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}