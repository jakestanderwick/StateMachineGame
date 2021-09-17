using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class StateController : MonoBehaviour
{
    public State curState;

    //for wandering
    public NavMeshAgent agent;
    public GameObject[] spawns;
    public int maxSpawns;
    public int whichSpawn;
    public int timer = 0;
    //end wandering

    public bool samsWanderState = true;
    public bool samsChaseState = false;

    public GameObject target = null;
    // Start is called before the first frame update
    void Start()
    {

        if (samsWanderState) SetState(new SamWanderState(this));
        if (samsChaseState) SetState(new SamChaseState(this));


    }

    // Update is called once per frame
    void Update()
    {
        curState.Transition();
        curState.Act();
    }
    public void SetName()
    {
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
        whichSpawn = Random.Range(0, maxSpawns);
    }

    public void DetectionSphereTriggerHandler(GameObject go)
    {

        target = go;
    }

    public GameObject CheckTarget()
    {
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
    public void NoDetection()
    {
        target = null;
    }
}
