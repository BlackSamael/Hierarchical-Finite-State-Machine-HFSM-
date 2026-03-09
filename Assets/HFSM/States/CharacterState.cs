public abstract class CharacterState : HFSMState
{
    protected CharacterState(HFSMStateMachine machine, HFSMContext context, HFSMState parent)
        : base(machine, context, parent)
    {
    }
}