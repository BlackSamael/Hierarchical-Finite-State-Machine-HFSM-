public class DeathState : HFSMState
{
    public DeathState(HFSMStateMachine machine, HFSMContext context, HFSMState parent)
        : base(machine, context, parent)
    {
    }

    public override void Enter()
    {
        context.ForceDeath = false; // Reset the flag to prevent unintended deaths
        // context.Animator?.Play("Death"); // Move this to a animation handling class later
        EventBus.Publish(new PlayerDiedEvent());
    }

    public override void Tick()
    {
        // Usually empty
        // Dead characters normally do nothing
    }
}