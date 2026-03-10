public class DeathState : HFSMState
{
    public DeathState(HFSMStateMachine machine, HFSMContext context, HFSMState parent)
        : base(machine, context, parent)
    {
    }

    public override void Enter()
    {
        context.ForceDeath = false;
    }

    public override void Tick()
    {
        // Usually empty
        // Dead characters normally do nothing
    }
}