public class HFSMTransition
{
    public HFSMState TargetState;
    public ITransitionCondition Condition;
    public int Priority;

    public HFSMTransition(HFSMState targetState, ITransitionCondition condition, int priority = 0)
    {
        TargetState = targetState;
        Condition = condition;
        Priority = priority;
    }

    public bool ShouldTransition(HFSMContext context)
    {
        return Condition.Evaluate(context);
    }
}