using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamWanderState : State
{
    public SamWanderState(StateController stateController) : base(stateController) { }
    public override void Enter()
    {
        stateController.SetName();
        stateController.maxSpawns = stateController.spawns.Length;
        stateController.SetNewSpawnToWanderTo();
    }

    public override void Act()
    {
        Vector3 spot;
        spot = new Vector3(stateController.spawns[stateController.whichSpawn].transform.position.x, 0, stateController.spawns[stateController.whichSpawn].transform.position.z);
        stateController.agent.destination = spot;

        float distance = Vector3.Distance(stateController.agent.gameObject.transform.position, spot);
        if (distance <= 2)
        {
            stateController.timer++;
            if (stateController.timer >= 1000) stateController.SetNewSpawnToWanderTo();
        }
    }

    public override void Transition()
    {
        GameObject targ = stateController.CheckTarget();
        if(targ != null)
        {
            if (targ.tag == "carrot" || targ.tag == "player")
            {
                stateController.SetState(new SamChaseState(stateController));
            }
        }
        
    }
}
