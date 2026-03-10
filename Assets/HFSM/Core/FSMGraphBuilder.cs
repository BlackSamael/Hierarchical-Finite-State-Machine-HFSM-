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
        DeathState death = new DeathState(machine, context, root);


        machine.IdleState = idle;
        machine.WalkState = walk;
        machine.JumpState = jump;
        machine.AttackState = attack;
        machine.DeathState = death;


        var moveCondition = new MoveCondition();
        var stopMoveCondition = new StopMoveCondition();
        var jumpCondition = new JumpPressedCondition();
        var attackCondition = new AttackPressedCondition();
        var deathCondition = new DeathCondition();


        machine.AddGlobalTransition(death, deathCondition);

        // Movement
        idle.AddTransition(walk, moveCondition);
        walk.AddTransition(idle, stopMoveCondition);

        // Jump
        idle.AddTransition(jump, jumpCondition);
        walk.AddTransition(jump, jumpCondition);

        // Attack
        idle.AddTransition(attack, attackCondition);
        walk.AddTransition(attack, attackCondition);

        machine.SetInitialState(idle);

        return machine;
    }
}