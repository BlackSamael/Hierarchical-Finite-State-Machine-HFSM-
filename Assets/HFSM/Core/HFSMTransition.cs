public class HFSMTransition
{
    public HFSMState TargetState;
    private ITransitionCondition condition;

    public HFSMTransition(HFSMState targetState, ITransitionCondition condition)
    {
        TargetState = targetState;
        this.condition = condition;
    }

    public bool ShouldTransition(HFSMContext context)
    {
        return condition.Evaluate(context);
    }
}