public class IdleState : GroundedState
{
    public IdleState(HFSMStateMachine machine, HFSMContext context, HFSMState parent)
        : base(machine, context, parent)
    {
    }

    public override void Enter()
    {
        context.Animator?.Play("Idle");
    }

    public override void Tick()
    {
        base.Tick();
    }
}