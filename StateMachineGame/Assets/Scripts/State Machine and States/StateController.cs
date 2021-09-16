using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public State curState;
    // Start is called before the first frame update
    void Start()
    {
        SetState(new WanderState(this));
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
}
