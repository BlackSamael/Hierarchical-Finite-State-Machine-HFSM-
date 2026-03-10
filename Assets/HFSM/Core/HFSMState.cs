using System.Collections.Generic;

public abstract class HFSMState
{
    protected HFSMStateMachine machine;
    public HFSMContext context;
    protected HFSMState parent;

    private List<HFSMTransition> transitions = new List<HFSMTransition>();
    public HFSMState Parent => parent;

    public IEnumerable<HFSMTransition> GetTransitions()
    {
        return transitions;
    }

    public HFSMState(HFSMStateMachine machine, HFSMContext context, HFSMState parent)
    {
        this.machine = machine;
        this.context = context;
        this.parent = parent;
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void Tick()
    {
        parent?.Tick();
    }

    public void AddTransition(HFSMState targetState, ITransitionCondition condition)
    {
        transitions.Add(new HFSMTransition(targetState, condition));
    }

    public HFSMState CheckTransitions()
    {
        foreach (var transition in transitions)
        {
            if (transition.ShouldTransition(context))
                return transition.TargetState;
        }

        return null;
    }
}