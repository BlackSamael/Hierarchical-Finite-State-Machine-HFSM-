public class IdleState : GroundedState
{
    public IdleState(HFSMStateMachine machine, HFSMContext context, HFSMState parent)
        : base(machine, context, parent)
    {
    }

    public override void Enter()
    {
        context.Animator?.Play("Idle"); // Move this to a animation handling class later
        EventBus.Publish(new MovementStoppedEvent());
    }

    public override void Tick()
    {
        base.Tick();
    }
}