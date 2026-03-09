using System.Collections.Generic;

public class StateMachine
{
    private IState _currentState;

    private readonly Dictionary<IState, List<Transition>> _transitions = new();

    public void SetInitialState(IState state)
    {
        _currentState = state;
        _currentState.Enter();
    }

    public void AddTransition(IState from, IState to, System.Func<bool> condition)
    {
        if (!_transitions.ContainsKey(from))
            _transitions[from] = new List<Transition>();

        _transitions[from].Add(new Transition(condition, to));
    }

    public void Tick()
    {
        if (_currentState == null)
            return;

        if (_transitions.TryGetValue(_currentState, out var transitions))
        {
            foreach (var transition in transitions)
            {
                if (transition.Condition())
                {
                    ChangeState(transition.TargetState);
                    break;
                }
            }
        }

        _currentState.Tick();
    }

    public void ChangeState(IState newState)
    {
        if (_currentState == newState)
            return;

        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}