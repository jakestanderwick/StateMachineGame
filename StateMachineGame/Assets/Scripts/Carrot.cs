using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public PlayerController pc;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player" || other.gameObject.tag == "rabbit")
        {

            int rand = Random.Range(0, pc.carrotSpawnLocations.Length);
            Vector3 spawnLoc = new Vector3(pc.carrotSpawnLocations[rand].transform.position.x, transform.position.y, pc.carrotSpawnLocations[rand].transform.position.z);
            transform.position = spawnLoc;
        }
    }
}
