using UnityEngine;

[RequireComponent(typeof(Hero))]
public class HeroStateMachine : MonoBehaviour
{
    [SerializeField] private State _initialState;

    private State _currentState;
    private Target _target;

    public State CurrentState { get; }

    private void Start()
    {
        _target = GetComponent<Hero>().Target;
        Reset();
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        State nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Reset()
    {
        _currentState = _initialState;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }
}
