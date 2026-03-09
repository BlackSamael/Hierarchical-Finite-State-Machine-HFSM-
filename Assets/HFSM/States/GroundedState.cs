public class GroundedState : HFSMState
{
    public GroundedState(HFSMStateMachine machine, HFSMContext context, HFSMState parent)
        : base(machine, context, parent)
    {
    }

    public override void Tick()
    {
        if (!context.IsGrounded)
        {
            machine.ChangeState(machine.JumpState);
        }
    }
}