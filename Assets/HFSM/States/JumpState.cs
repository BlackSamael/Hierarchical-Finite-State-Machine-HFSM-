public class JumpState : HFSMState
{
    public JumpState(HFSMStateMachine machine, HFSMContext context, HFSMState parent)
        : base(machine, context, parent)
    {
    }

    public override void Enter()
    {
        context.Rigidbody.AddForce(UnityEngine.Vector2.up * context.JumpForce,
            UnityEngine.ForceMode.Impulse);
    }

    public override void Tick()
    {
        if (context.IsGrounded)
        {
            machine.ChangeState(machine.IdleState);
        }
    }
}