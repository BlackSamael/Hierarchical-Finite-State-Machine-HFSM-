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
        EventBus.Publish(new AttackStartedEvent());
        //context.Animator.Play(StateName); // Move this to a animation handling class later
    }

    public override void Tick()
    {
        attackTimer -= UnityEngine.Time.deltaTime;

        if (attackTimer <= 0f)
        {
            machine.ChangeState(machine.GetState<IdleState>());
        }
    }
}