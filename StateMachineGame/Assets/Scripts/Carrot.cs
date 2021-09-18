using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public PlayerController pc;
    public GameManager gm;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {

            Vector3 spawnLoc;
            spawnLoc = gm.PickNewCarrotSpawn(other.gameObject);
            transform.position = spawnLoc;
        }
        if(other.gameObject.tag == "rabbit")
        {
            Vector3 spawnLoc = gm.PickNewCarrotSpawn(other.gameObject);
            transform.position = spawnLoc;
            gm.rabbitPickedUpCarrot(other.gameObject.GetComponent<StateController>());
        }
    }
}
