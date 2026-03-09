public static class FSMGraphBuilder
{
    public static HFSMStateMachine Build(HFSMContext context)
    {
        HFSMStateMachine machine = new HFSMStateMachine();

        RootState root = new RootState(machine, context);

        IdleState idle = new IdleState(machine, context, root);
        WalkState walk = new WalkState(machine, context, root);
        JumpState jump = new JumpState(machine, context, root);
        AttackState attack = new AttackState(machine, context, root);

        machine.IdleState = idle;
        machine.WalkState = walk;
        machine.JumpState = jump;
        machine.AttackState = attack;

        // Movement transitions
        idle.AddTransition(walk, () => context.MoveInput != 0);
        walk.AddTransition(idle, () => context.MoveInput == 0);

        // Jump transitions
        idle.AddTransition(jump, () => context.JumpPressed && context.IsGrounded);
        walk.AddTransition(jump, () => context.JumpPressed && context.IsGrounded);

        // Attack transitions
        idle.AddTransition(attack, () => context.AttackPressed);

        machine.SetInitialState(idle);

        return machine;
    }
}