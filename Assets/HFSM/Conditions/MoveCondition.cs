public class MoveCondition : ITransitionCondition
{
    public bool Evaluate(HFSMContext context)
    {
        return context.MovePressed;
    }
}