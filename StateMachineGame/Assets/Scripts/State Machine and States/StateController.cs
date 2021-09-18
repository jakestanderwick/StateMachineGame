using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class StateController : MonoBehaviour
{
    public State curState;

    public NavMeshAgent agent;
    public GameObject[] spawns;
    public int maxSpawns;
    public int whichSpawn;
    public int timer = 0;

    public bool samsWanderState = true;
    public bool samsChaseState = false;
    //ATTENTION
    /*
    I recommend placing bools in here so we can switch between who's state machine we are using. It is a lot easier
    to do that so we can set whichever state machine we want when we place it in the scene.
    */

    public GameObject target = null;

    public GameObject objInRadius = null;

    //for leveling
    public int rabbitLevel = 1;
    public int rabbitCarrotsCollected = 0;
    //end leveling
    // Start is called before the first frame update
    void Start()
    {

        if (samsWanderState) SetState(new SamWanderState(this));
        if (samsChaseState) SetState(new SamChaseState(this));
        //set the starting state to whatever is toggled.

    }

    // Update is called once per frame
    void Update()
    {
        curState.Transition();
        curState.Act();
    }
    public void SetName()
    {
        //for testing.
        gameObject.name = "in State: " + curState;
    }
    public void SetState(State s)
    {
        if (curState != null) curState.Exit();

        curState = s;

        if (curState != null) curState.Enter();
    }
    public void SetNewSpawnToWanderTo()
    {
        //a way to patrol to random points.
        whichSpawn = Random.Range(0, maxSpawns);
    }

    public void DetectionSphereTriggerHandler(GameObject go)
    {
        //this is just to get the collision detection for the detection sphere.
        //its not as eloquent as the way i did it 
        //with the attack spheres, but it works.
        //the detection sends the game object to this 
        //method which allows the state controller to
        //store a target. Each state can then access it.
        target = go;
    }

    public GameObject CheckTarget()
    {
        //checks to see what's there. If it's a player or carrot, return the respective.
        if(target != null)
        {
            if (target == GameObject.Find("Player"))
            {
                return GameObject.Find("Player");
            }
            if (target.tag == "carrot")
            {
                return target;
            }
        }

        return null;
    }

    //for if the target leaves the detection sphere
    public void NoDetection()
    {
        target = null;
    }
}
