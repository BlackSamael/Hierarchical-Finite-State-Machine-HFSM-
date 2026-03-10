public class AttackPressedCondition : ITransitionCondition
{
    public bool Evaluate(HFSMContext context)
    {
        return context.AttackPressed;
    }
}