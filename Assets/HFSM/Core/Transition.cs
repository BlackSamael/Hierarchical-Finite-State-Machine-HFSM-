using System;

public class Transition
{
    public Func<bool> Condition;
    public IState TargetState;

    public Transition(Func<bool> condition, IState target)
    {
        Condition = condition;
        TargetState = target;
    }
}