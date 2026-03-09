using System;

public class HFSMTransition
{
    public HFSMState TargetState;
    public Func<bool> Condition;

    public HFSMTransition(HFSMState targetState, Func<bool> condition)
    {
        TargetState = targetState;
        Condition = condition;
    }

    public bool ShouldTransition()
    {
        return Condition();
    }
}