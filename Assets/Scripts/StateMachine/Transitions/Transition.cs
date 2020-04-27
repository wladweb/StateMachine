using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Target Target { get; private set; }

    public bool NeedTransit { get; protected set; }
    public State TargetState
    {
        get 
        {
            return _targetState;
        }
    }

    public void Init(Target target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
