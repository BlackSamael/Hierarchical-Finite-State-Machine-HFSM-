public class JumpPressedCondition : ITransitionCondition
{
    public bool Evaluate(HFSMContext context)
    {
        return context.JumpPressed;
    }
}