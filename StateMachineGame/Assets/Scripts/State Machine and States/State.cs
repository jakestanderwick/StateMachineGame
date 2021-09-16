using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected StateController stateController;

    public State(StateController stateController)
    {
        this.stateController = stateController;
    }
    // Start is called before the first frame update
    public abstract void Transition();

    public abstract void Act();

    public virtual void Enter() { }

    public virtual void Exit() { }
}
