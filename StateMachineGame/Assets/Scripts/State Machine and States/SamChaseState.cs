using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamChaseState : State
{
    public SamChaseState(StateController sc) : base(sc) { }
    private GameObject target;
    public override void Enter()
    {
        stateController.SetName();
        GameObject targ = stateController.CheckTarget();
        if (targ.tag == "player") target = targ;
        else if (targ.tag == "carrot") target = targ;
    }

    public override void Act()
    {
        
        stateController.agent.SetDestination(target.transform.position);
    }

    public override void Transition()
    {

        Vector3 spot;
        spot = new Vector3(target.transform.position.x, 0, target.transform.position.z);

        float distance = Vector3.Distance(stateController.agent.gameObject.transform.position, spot);
        Debug.Log(distance);
        if (distance >= 10)
        {
            stateController.SetState(new SamWanderState(stateController));
        }
    }
}
