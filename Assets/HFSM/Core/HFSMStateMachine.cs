using System.Collections.Generic;

public class HFSMStateMachine
{
    private HFSMState currentState;

    public HFSMState IdleState;
    public HFSMState WalkState;
    public HFSMState JumpState;
    public HFSMState AttackState;

    public HFSMState DeathState;

    public HFSMState CurrentState => currentState;
    private List<HFSMTransition> globalTransitions = new List<HFSMTransition>();

    public void SetInitialState(HFSMState state)
    {
        currentState = state;
        currentState.Enter();
    }

    public void AddGlobalTransition(HFSMState targetState, ITransitionCondition condition)
    {
        globalTransitions.Add(new HFSMTransition(targetState, condition));
    }

    private HFSMState CheckGlobalTransitions()
    {
        foreach (var transition in globalTransitions)
        {
            if (transition.ShouldTransition(currentState.context))
            {
                return transition.TargetState;
            }
        }

        return null;
    }

    public void Tick()
    {
        if (currentState == null)
            return;

        HFSMState transition = CheckGlobalTransitions();

        if (transition == null)
        {
            transition = CheckHierarchicalTransitions();
        }

        if (transition != null)
        {
            ChangeState(transition);
        }

        currentState.Tick();
    }

    private HFSMState CheckHierarchicalTransitions()
    {
        HFSMState state = currentState;

        while (state != null)
        {
            HFSMState transition = state.CheckTransitions();

            if (transition != null)
                return transition;

            state = state.Parent;
        }

        return null;
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