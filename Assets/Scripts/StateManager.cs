using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager
{
    public IState state;

    public StateManager(IState state)
    {
        this.state = state;
    }

    public void SetState(IState state)
    {
        this.state = state;
    }

    public void Oper()
    {
        state.Operation();
    }
};
