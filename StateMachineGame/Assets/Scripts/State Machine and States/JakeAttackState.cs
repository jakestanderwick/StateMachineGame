using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JakeAttackState : State
{
    public JakeAttackState(StateController stateController) : base(stateController) { }

    //makes the rabbit have to wait before killing player, so they can escape
    private int attackTimer = 0;
    private float teleportTimer = 0f;

    //if player exits the attack radius, then transition to new state.
    private bool canTransit = false;
    public override void Enter()
    {
        stateController.SetName();
    }
    public void Start()
    {
        //teleportTimer += Time.deltaTime;
    }

    public override void Act()
    {
        //checking to see if its not the player inside the attack radius
        //teleportTimer += Time.deltaTime;
        if(stateController.objInRadius.tag != "player")
        {
            canTransit = true;
        }

        //sets destination to where it currently is
        stateController.agent.SetDestination(stateController.agent.transform.position);
        //if it is indeed a player, start a timer to attack.
        //500 is a little long, but this is for test.
        //sets the player object to inactive.
        //then exits the state.
        if(stateController.objInRadius.tag == "player")
        {
            //Vector3 teleportSpot;
            //teleportSpot = new Vector3(stateController.agent.transform.position.x, 5 ,stateController.agent.transform.position.z);
            //Debug.Log(teleportTimer);
            //Debug.Log(teleportSpot);
            if(attackTimer >= 70)
            {
                stateController.objInRadius.SetActive(false);
                canTransit = true;
            }
            attackTimer++;
        }
        //Debug.Log("Obj in rad = " + stateController.objInRadius.name);
    }

    public override void Transition()
    {
        if (canTransit) stateController.SetState(new JakeWanderState(stateController));
    }
}
