using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JakeWanderState : State
{
    public JakeWanderState(StateController stateController) : base(stateController) { }
    public bool tDo;
    public float timerV = 0f;
    public override void Enter()
    {
        stateController.SetName();
        stateController.maxSpawns = stateController.spawns.Length;
        stateController.SetNewSpawnToWanderTo();
        
    }

    public override void Act()
    {
        if (stateController.rabbitLevel > 1) stateController.agent.speed = 8;
        Vector3 spot;
        spot = new Vector3(stateController.spawns[stateController.whichSpawn].transform.position.x, 0, stateController.spawns[stateController.whichSpawn].transform.position.z);
        stateController.agent.destination = spot;
        timerV += Time.deltaTime;
        //Debug.Log(timerV);

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
                stateController.SetState(new JakeChaseState(stateController));
            }
        }
        
    }
}
