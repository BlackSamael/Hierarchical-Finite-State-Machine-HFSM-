public class DeathCondition : ITransitionCondition
{
    public bool Evaluate(HFSMContext context)
    {
        return context.ForceDeath;
    }
}