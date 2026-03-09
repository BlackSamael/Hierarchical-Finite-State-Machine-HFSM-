public class AttackState : GroundedState
{
    private const string StateName = "Attack";
    private float attackTimer;

    public AttackState(HFSMStateMachine machine, HFSMContext context, HFSMState parent)
        : base(machine, context, parent)
    {
    }

    public override void Enter()
    {
        attackTimer = 0.5f;
        context.Animator.Play(StateName);
    }

    public override void Tick()
    {
        attackTimer -= UnityEngine.Time.deltaTime;

        if (attackTimer <= 0f)
        {
            machine.ChangeState(machine.IdleState);
        }
    }
}