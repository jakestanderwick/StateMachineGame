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

        //sets the target of the chase as whatever was in the radius of detection
        GameObject targ = stateController.CheckTarget();
        if (targ.tag == "player") target = targ;
        else if (targ.tag == "carrot") target = targ;
        
    }

    public override void Act()
    {
        if(stateController.rabbitLevel > 1)
        {
            stateController.agent.speed += 0.2f;
        }
        //goes to it.
        stateController.agent.SetDestination(target.transform.position);
    }

    public override void Transition()
    {
        //checks distance of the object that's in radius.
        //if the object is no longer in the raidus (i.e. slips away or rabbit can't see it from manuevering)
        //then exit to the wanter state.
        Vector3 spot;
        spot = new Vector3(target.transform.position.x, 0, target.transform.position.z);

        float distance = Vector3.Distance(stateController.agent.gameObject.transform.position, spot);
        Debug.Log(distance);
        if (distance >= 10)
        {
            stateController.SetState(new SamWanderState(stateController));
        }

        //if its close enough to it and its the player, go to attack state.
        if (distance <= 2.5 && stateController.objInRadius.tag == "player") stateController.SetState(new SamAttackState(stateController));
    }
}
