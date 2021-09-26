using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JakeTeleportState : State
{
    public JakeTeleportState(StateController stateController) : base(stateController) { }
    //private GameObject target;
    private bool isTeleported;
    private bool isDone = false;
    public static int teleCount = 0;
    public override void Enter()
    {
        stateController.SetName();
        //target = targ;
    }

    public override void Act()
    {
        // if(teleCount <= 3)
        // {
        //     Vector3 teleportSpot;
        //     teleportSpot = new Vector3(stateController.agent.transform.position.x, stateController.agent.transform.position.y, 5);
        //     Debug.Log(teleportSpot);
        //     stateController.agent.gameObject.transform.position = teleportSpot;
        //     isTeleported = true;
        //     teleCount++;
        // } else
        // {
        //     isDone = true;
        // }
        Vector3 teleportSpot;
        teleportSpot = new Vector3(stateController.agent.transform.position.x, stateController.agent.transform.position.y, 5);
        //Debug.Log(teleportSpot);
        stateController.agent.gameObject.transform.position = teleportSpot;
        isTeleported = true;
        teleCount++;
    }

    public override void Transition()
    {
        if(isTeleported) stateController.SetState(new JakeWanderState(stateController));
        //if(isDone) stateController.SetState(new JakeChaseState(stateController));
    }
}
