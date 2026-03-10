public static class FSMGraphBuilder
{
    public static HFSMStateMachine Build(HFSMContext context)
    {
        HFSMStateMachine machine = new HFSMStateMachine();

        RootState root = new RootState(machine, context);

        var idle = machine.CreateState<IdleState>(context, root);
        var walk = machine.CreateState<WalkState>(context, root);
        var jump = machine.CreateState<JumpState>(context, root);
        var attack = machine.CreateState<AttackState>(context, root);
        var death = machine.CreateState<DeathState>(context, root);

        var moveCondition = new MoveCondition();
        var stopMoveCondition = new StopMoveCondition();
        var jumpCondition = new JumpPressedCondition();
        var attackCondition = new AttackPressedCondition();
        var deathCondition = new DeathCondition();

        machine.AddGlobalTransition(death, deathCondition, 100);

        idle.AddTransition(walk, moveCondition, 10);
        walk.AddTransition(idle, stopMoveCondition, 10);

        idle.AddTransition(jump, jumpCondition, 30);
        walk.AddTransition(jump, jumpCondition, 30);

        idle.AddTransition(attack, attackCondition, 40);

        machine.SetInitialState(idle);

        return machine;
    }
}