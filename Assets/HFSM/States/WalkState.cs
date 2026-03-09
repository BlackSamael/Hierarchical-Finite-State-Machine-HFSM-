public class WalkState : GroundedState
{
    public WalkState(HFSMStateMachine machine, HFSMContext context, HFSMState parent)
        : base(machine, context, parent)
    {
    }

    public override void Enter()
    {
        context.Animator?.Play("Walk");
    }

    public override void Tick()
    {
        base.Tick();

        context.Rigidbody.linearVelocity = new UnityEngine.Vector2(
            context.MoveInput * 5f,
            context.Rigidbody.linearVelocity.y
        );
    }
}