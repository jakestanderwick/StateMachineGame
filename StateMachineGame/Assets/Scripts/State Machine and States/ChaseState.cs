using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public ChaseState(StateController sc) : base(sc) { }
    public override void Enter()
    {
        stateController.SetName();
    }

    public override void Act()
    {

    }

    public override void Transition()
    {
        if(Input.GetKey(KeyCode.H))
        {
            stateController.SetState(new WanderState(stateController));
        }
    }
}