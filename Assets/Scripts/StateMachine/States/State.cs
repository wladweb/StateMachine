﻿using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    private List<Transition> _transitions;

    protected Target Target { get; set; }

    public void Enter(Target target)
    {
        if (!enabled)
        {
            Target = target;
            enabled = true;

            foreach (Transition transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(target);
            }
        }
    }

    public State GetNextState()
    {
        foreach (Transition transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }

    public void Exit()
    {
        if (enabled) 
        {
            foreach (Transition transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }
}
