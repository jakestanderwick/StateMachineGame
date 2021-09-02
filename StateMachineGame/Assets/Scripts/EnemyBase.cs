using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBase : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject[] spawns;
    private int maxSpawns;
    private int whichSpawn;
    private int timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        maxSpawns = spawns.Length;
        whichSpawn = Random.Range(0, maxSpawns);


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spot;
        spot = new Vector3(spawns[whichSpawn].transform.position.x, 0, spawns[whichSpawn].transform.position.z);
        agent.destination = spot;
        print("My destination is " + spawns[whichSpawn].name);
        print("Spot = " + spot);
        float distance = Vector3.Distance(agent.gameObject.transform.position, spot);
        print(distance);
        if(distance <= 2)
        {
            timer++;
            if (timer >= 1000) PickNewSpot();
        }
    }

    void PickNewSpot()
    {
        whichSpawn = Random.Range(0, maxSpawns);
    }
}
