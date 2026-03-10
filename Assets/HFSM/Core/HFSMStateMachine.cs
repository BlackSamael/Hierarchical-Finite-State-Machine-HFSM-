using System;
using System.Collections.Generic;

public class HFSMStateMachine
{
    private HFSMState currentState;
    private HFSMState requestedState;

    public HFSMState CurrentState => currentState;
    private List<HFSMTransition> globalTransitions = new List<HFSMTransition>();
    private Dictionary<Type, HFSMState> stateRegistry = new();
    public void SetInitialState(HFSMState state)
    {
        currentState = state;
        currentState.Enter();
    }

    public void AddGlobalTransition(HFSMState targetState, ITransitionCondition condition, int priority = 0)
    {
        globalTransitions.Add(new HFSMTransition(targetState, condition, priority));
    }

    private HFSMState CheckGlobalTransitions()
    {
        foreach (var transition in globalTransitions)
        {
            if (transition.ShouldTransition(currentState.context))
            {
                return transition.TargetState;
            }
        }

        return null;
    }

    public void Tick()
    {
        if (currentState == null)
            return;

        HFSMState transition = CheckGlobalTransitions();

        if (transition == null)
        {
            transition = CheckHierarchicalTransitions();
        }

        if (transition != null)
        {
            RequestTransition(transition);
        }

        currentState.Tick();
        if (requestedState != null)
        {
            ChangeState(requestedState);
            requestedState = null;
        }
    }

    private HFSMState CheckHierarchicalTransitions()
    {
        HFSMState state = currentState;

        while (state != null)
        {
            HFSMState transition = state.CheckTransitions();

            if (transition != null)
                return transition;

            state = state.Parent;
        }

        return null;
    }

    public void ChangeState(HFSMState newState)
    {
        if (newState == currentState)
            return;

        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void RequestTransition(HFSMState state)
    {
        if (state == null)
            return;

        requestedState = state;
    }

    public void RegisterState(HFSMState state)
    {
        Type type = state.GetType();

        if (stateRegistry.ContainsKey(type))
        {
            throw new Exception($"State already registered: {type}");
        }

        stateRegistry.Add(type, state);
    }

    public T GetState<T>() where T : HFSMState
    {
        if (stateRegistry.TryGetValue(typeof(T), out var state))
            return (T)state;

        throw new Exception($"State not registered: {typeof(T)}");
    }
    public IEnumerable<HFSMState> GetAllStates()
    {
        return stateRegistry.Values;
    }

    public T CreateState<T>(HFSMContext context, HFSMState parent) where T : HFSMState
    {
        var state = (T)Activator.CreateInstance(typeof(T), this, context, parent);

        RegisterState(state);

        return state;
    }
}