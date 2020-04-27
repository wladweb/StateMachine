using UnityEngine;

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
        
    }

    private void Reset()
    {
        _currentState = _initialState;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }
}
