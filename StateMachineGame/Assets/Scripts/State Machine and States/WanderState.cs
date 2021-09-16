using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State
{
    public WanderState(StateController stateController) : base(stateController) { }
    public override void Enter()
    {
        stateController.SetName();
    }

    public override void Act()
    {

    }

    public override void Transition()
    {
        if(Input.GetKey(KeyCode.G))
        {
            stateController.SetState(new ChaseState(stateController));
        }
    }
}
