public class RootState : HFSMState
{
    public RootState(HFSMStateMachine machine, HFSMContext context)
        : base(machine, context, null)
    {
    }

    public override void Tick()
    {
        // Root doesn't execute gameplay logic
    }
}