public abstract class AirborneState : HFSMState
{
    protected AirborneState(HFSMStateMachine machine, HFSMContext ctx, HFSMState parent)
        : base(machine, ctx, parent)
    {
    }
}